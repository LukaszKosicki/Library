import React, { useState, useEffect } from 'react';
import { Table, Button } from 'reactstrap';

function Books() {
    const [books, setBooks] = useState([]);

    function getBooks() {
        fetch('api/book')
            .then(resp => resp.json())
            .then(resp => setBooks(resp))
    }

    useEffect(() => {
        getBooks();
    }, [])

    function deleteBook(bookId) {
        fetch('api/book/' + bookId, {
            method: 'delete'
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.result) {
                    getBooks();
                } else {
                    alert(resp.msg);
                }
            })
    }

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
                                <td><Button onClick={() => deleteBook(item.id)} type="button" color="link">Usuń</Button></td>
                            </tr>
                            );
                    })
                }
            </tbody>
        </Table>
        );

}

export default Books;