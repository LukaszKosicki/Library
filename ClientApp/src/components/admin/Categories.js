import React, { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { connect } from "react-redux";

function AddBook() {
    const [categories, setCategories] = useState([]);

    function getCategory() {
        fetch('api/category')
            .then(resp => resp.json())
            .then(resp => { setCategories(resp) })
    }

    function sendCategory() {
        var categoryModel = {

        }

        fetch('api/category', {
            method: "post",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(bookModel)
        })
    }

    useEffect(() => {
        getCategory();
    }, [])

    return (
        <Form>
            <FormGroup>
                <Label for="title">Tytuł</Label>
                <Input type="text" name="title" id="title" placeholder="Title" />
            </FormGroup>
            <Button onClick={() => { saveBook() }} type="button" color="warning">Dodaj książkę</Button>
        </Form>
    );

}

export default connect()(AddBook);