﻿import React, { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input, Table, FormText } from 'reactstrap';
import { connect } from "react-redux";

function Categories() {
    const [categories, setCategories] = useState([]);
    const [name, setName] = useState("");

    function getCategory() {
        fetch('api/category')
            .then(resp => resp.json())
            .then(resp => { setCategories(resp); setName(''); })
    }

    function deleteCat(id) {
        console.log(id);
        fetch('api/category/' + id, {
            method: 'DELETE'
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.result) {
                    getCategory();
                } else {
                    alert(resp.msg);
                }
            })   
    }

    function sendCategory() {
        var categoryModel = {
            name: name
        }

        fetch('api/category', {
            method: "post",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(categoryModel)
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.result) {
                    getCategory();
                } else {
                    alert(resp.msg);
                }
            })
    }

    useEffect(() => {
        getCategory();
    }, [])

    return (
        <div>
        <Form>
            <FormGroup>
                    <Label for="title">Tytuł</Label>
                    <Input value={name} onChange={(e) => setName(e.target.value)} type="text" name="title" id="title" placeholder="Title" />
            </FormGroup>
            <Button onClick={() => { sendCategory() }} type="button" color="warning">Dodaj</Button>
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
                        categories.map((item, index) => {
                            return (
                                <tr key={"cat" + index}>
                                    <th scope="row">{item.categoryId}</th>
                                    <td>{item.name}</td>
                                    <td><Button onClick={() => deleteCat(item.categoryId)} type="button" color="link">Usuń</Button></td>
                                </tr>
                            );
                        })
                    }
                </tbody>
            </Table>
        </div>
    );

}

export default connect()(Categories);