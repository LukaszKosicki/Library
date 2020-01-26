import React, { useState, useEffect } from 'react';
import { Table, Button } from 'reactstrap';
import { connect } from 'react-redux';

function Books(props) {
    const [books, setBooks] = useState([]);

    function getBooks() {
        fetch('api/book')
            .then(resp => resp.json())
            .then(resp => { console.log(resp); setBooks(resp);})
    }

    function rezerwuj(bookId) {
        console.log(props.user);
        fetch("api/loans?userId=" + props.user.user.id + "&bookId=" + bookId, {
            method: 'POST'
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.result) {
                    alert(resp.msg)
                } else {
                    alert(resp.msg);
                }
            })
    }

    useEffect(() => {
        getBooks();
    }, [])

    return (
        <Table striped>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {
                    books.map((item, index) => {
                        return (
                            <tr key={"book" + index}>
                                <th scope="row">{item.id}</th>
                                <td>{item.title}</td>
                                <td>{item.author}</td>
                                <td><Button onClick={() => { rezerwuj(item.id) }} type="button" color="link">Zarezerwuj</Button></td>
                            </tr>
                            );
                    })
                }
            </tbody>
        </Table>
        );

}

const mapStateToProps = state => ({
    user: state.user
});

export default connect(mapStateToProps)(Books);