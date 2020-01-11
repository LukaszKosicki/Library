import React, { useState, useEffect } from 'react';
import { Table, Button } from 'reactstrap';

function BookLoans() {
    const [books, setBooks] = useState([]);

    function getBooks() {
        fetch('api/admin')
            .then(resp => resp.json())
            .then(resp => {
              setBooks(resp)
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
                    <th>Data wypożyczenia</th>
                    <th>Data zwrotu</th>
                </tr>
            </thead>
            <tbody>
                {
                    books.length === 0 && <h4>Brak zapytań</h4>
                }
                {
                    books.length > 0 && books.map((item, index) => {
                        return (
                            <tr key={"book" + index}>
                                <th scope="row">{item.id}</th>
                                <td>{item.title}</td>
                                <td>{item.author}</td>
                                <td>{item.date_out}</td>
                                <td>{item.date_in}</td>
                            </tr>
                        );
                    })
                }
            </tbody>
        </Table>
    );

}

export default BookLoans;