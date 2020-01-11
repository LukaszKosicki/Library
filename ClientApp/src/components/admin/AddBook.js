import React, { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { connect } from "react-redux";

function AddBook() {
    const [authors, setAuthors] = useState([]);
    const [categories, setCategories] = useState([]);
    const [title, setTitle] = useState([]);
    const [author, setAuthor] = useState('');
    const [category, setCategory] = useState('');
    const [ilosc, setIlosc] = useState(0);
    

    function getAuthors() {
        fetch('api/author')
            .then(resp => resp.json())
            .then(resp => { setAuthors(resp) })
    }

    function getCategory() {
        fetch('api/category')
            .then(resp => resp.json())
            .then(resp => { setCategories(resp) })
    }

    function saveBook() {
        var bookModel = {
            title: title,
            author: author,
            category: category,
            copiesNo: ilosc
        }
 
        fetch("api/book", {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(bookModel)
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.result) {

                } else {
                    alert(resp.msg);
                }
            })
    }

   useEffect(() => {
       getAuthors();
       getCategory();
    }, [])

    return (
        <Form>
            <FormGroup>
                <Label for="title">Tytuł</Label>
                <Input onChange={(e) => setTitle(e.target.value)} type="text" name="title" id="title" placeholder="Title" />
            </FormGroup>           
            <FormGroup>
                <Label for="ilosc">Ilość książek</Label>
                <Input onChange={(e) => setIlosc(e.target.value)} type="number" name="ilosc" id="ilosc" placeholder="Ilosc książek" />
            </FormGroup>
            <FormGroup>
                <Label for="selectAuthor">Autor</Label>
                <Input onChange={(e) => setAuthor(e.target.value)} type="select" name="selectAuthor" id="selectAuthor">
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
                <Input onChange={(e) => setCategory(e.target.value)} type="select" name="selectCategory" id="selectCategory">
                    {
                        categories.map((item, index) => {
                            return (
                                <option key={"cat" + index}>{item.name}</option>
                            );
                        })
                    }
                </Input>
            </FormGroup>
            <Button onClick={() => { saveBook() }} type="button" color="warning">Dodaj książkę</Button>
        </Form>
        );

}

export default connect()(AddBook);