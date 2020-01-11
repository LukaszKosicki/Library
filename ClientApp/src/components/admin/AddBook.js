import React, { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { connect } from "react-redux";

function AddBook() {
    const [authors, setAuthors] = useState([]);
    const [categories, setCategories] = useState([]);

    function getAuthors() {
        fetch('api/author')
            .then(resp => resp.json())
            .then(resp => { setAuthors(resp) })
    }

    function getCategory() {
        fetch('api/category')
            .then(resp => resp.json())
            .then(resp => { console.log(categories); setCategories(resp) })
    }

   useEffect(() => {
       getAuthors();
       getCategory();
    }, [])

    return (
        <Form>
            <FormGroup>
                <Label for="title">Tytuł</Label>
                <Input type="text" name="title" id="title" placeholder="Title" />
            </FormGroup>
            <FormGroup>
            <Label for="selectAuthor">Autor</Label>
            <Input type="select" name="selectAuthor" id="selectAuthor">
                {
                    authors.map((item, index) => {
                        return (
                            <option key={"opt" + index}>{item.name}</option>
                        );
                    })
                }
                </Input>
            </FormGroup>
            <FormGroup>
                <Label for="selectCategory">Kategoria:</Label>
                <Input type="select" name="selectCategory" id="selectCategory">
                    {
                        categories.map((item, index) => {
                            return (
                                <option key={"cat" + index}>{item.name}</option>
                            );
                        })
                    }
                </Input>
            </FormGroup>
        </Form>
        );

}

export default connect()(AddBook);