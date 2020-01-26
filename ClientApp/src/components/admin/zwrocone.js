import React, { useState, useEffect } from 'react';
import { Table, Button } from 'reactstrap';

function BookZwrot() {
    const [books, setBooks] = useState([]);
    const users = ["janek@test.pl", "mariusz@test.pl", "mariola@test.pl", "jola@test.pl"];
  
    function getBooks() {
        fetch('api/admin?czy=4')
            .then(resp => resp.json())
            .then(resp => {
                console.log(resp);
                setBooks(resp)
            })
    }

    function wypozycz(loansId) {

        fetch("api/admin?id=" + loansId + "&czy=true", {
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
                    <td>Data wypożyczenia</td>
                    <td>Data zwrotu</td>
                  
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
                                <td>{item.wyp}</td>
                                <td>{item.zwrot}</td>
          
                            </tr>
                        );
                    })
                }
            </tbody>
        </Table>
    );

}

export default BookZwrot;