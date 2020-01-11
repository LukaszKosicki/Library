import React, { useState, useEffect } from 'react';
import { Table, Button } from 'reactstrap';

function Books() {
    const [books, setBooks] = useState([]);

    useEffect(() => {
        fetch('api/book')
            .then(resp => resp.json())
            .then(resp => setBooks(resp))
    })

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
                    books.map(item => {
                        return (
                            <tr>
                                <th scope="row">{item.id}</th>
                                <td>{item.title}</td>
                                <td>{item.author}</td>
                                <td><Button type="button" color="link">Usuń</Button></td>
                            </tr>
                            );
                    })
                }
            </tbody>
        </Table>
        );

}

export default Books;