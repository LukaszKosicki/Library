import React, { useState, useEffect } from 'react';
import { Table, Button } from 'reactstrap';

function Users() {
    const [users, setUsers] = useState([]);

    function getUsers() {
        fetch('api/user')
            .then(resp => resp.json())
            .then(resp => setUsers(resp))
    }

    useEffect(() => {
        getUsers();
    })

    function deleteUser(userId) {
        console.log(userId);
        fetch('api/user/' + userId, {
            method: 'DELETE'
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.deleteResult) {
                    getUsers();
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
                    <th>UserName</th>
                    <th>Email</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {
                    users.map(item => {
                        return (
                            <tr>
                                <th scope="row">{item.id}</th>
                                <td>{item.userName}</td>
                                <td>{item.email}</td>
                                <td><Button onClick={() => deleteUser(item.id)} type="button" color="link">Usuń</Button></td>
                            </tr>
                            );
                    })
                }
            </tbody>
        </Table>
        );

}

export default Users;