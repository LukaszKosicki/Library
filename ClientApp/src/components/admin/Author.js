import React, { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input, Table, FormText } from 'reactstrap';
import { connect } from "react-redux";

function Author() {
    const [authors, setAuthors] = useState([]);
    const [name, setName] = useState("");

    function getAuthor() {
        fetch('api/author')
            .then(resp => resp.json())
            .then(resp => { setAuthors(resp); setName(''); })
    }

    function deleteCat(id) {
        console.log(id);
        fetch('api/author/' + id, {
            method: 'DELETE'
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.result) {
                    getAuthor();
                } else {
                    alert(resp.msg);
                }
            })   
    }

    function sendAuthor() {
        var categoryModel = {
            name: name
        }

        fetch('api/author', {
            method: "post",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(categoryModel)
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.result) {
                    getAuthor();
                } else {
                    alert(resp.msg);
                }
            })
    }

    useEffect(() => {
        getAuthor();
    }, [])

    return (
        <div>
        <Form>
            <FormGroup>
                    <Label for="name">Autor</Label>
                    <Input value={name} onChange={(e) => setName(e.target.value)} type="text" name="name" id="name" placeholder="Autor" />
                </FormGroup>
                <Button onClick={() => { sendAuthor() }} type="button" color="warning">Dodaj</Button>
        </Form>
            <Table striped>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nazwa</th>
                        <th>Akcje</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        authors.map((item, index) => {
                            return (
                                <tr key={"cat" + index}>
                                    <th scope="row">{item.authorId}</th>
                                    <td>{item.name}</td>
                                    <td><Button onClick={() => deleteCat(item.authorId)} type="button" color="link">Usuń</Button></td>
                                </tr>
                            );
                        })
                    }
                </tbody>
            </Table>
        </div>
    );

}

export default connect()(Author);