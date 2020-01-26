import React, { useState, useEffect } from 'react';
import { Table, Button } from 'reactstrap';

function BookZwroc() {
    const [books, setBooks] = useState([]);
    const users = ["janek@test.pl", "mariusz@test.pl", "mariola@test.pl", "jola@test.pl"];

    function getBooks() {
        fetch('api/admin?czy=1')
            .then(resp => resp.json())
            .then(resp => {
                console.log(resp);
                setBooks(resp)
            })
    }

    function wypozycz(loansId) {

        fetch("api/admin?id=" + loansId + "&czy=false", {
            method: 'PATCH'
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
                    books.length === 0 && <h4>Brak zapytań</h4>
                }
                {
                    books.length > 0 && books.map((item, index) => {
                        console.log(item);
                        return (
                            <tr key={"book" + index}>
                                <th scope="row">{index + 1}</th>
                                <td>{item.title}</td>
                                <td>{item.name}</td>
                                <td><Button onClick={() => wypozycz(item.id)} type="button" color="link">Zwrot</Button></td>
                            </tr>
                        );
                    })
                }
            </tbody>
        </Table>
    );

}

export default BookZwroc;