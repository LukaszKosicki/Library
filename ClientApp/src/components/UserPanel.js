import React, {useState} from 'react';
import { connect } from 'react-redux';
import './Main.css';
import { TabContent, TabPane, Nav, NavItem, NavLink, Card, Button, CardTitle, CardText, Row, Col, Container, Table } from 'reactstrap';

import Greeting from '../components/common/Greeting';
import Books from "../components/user/Books";
import Tabs from ".././components/user/Tabs";

const UserPanel = props => (
    <section className="documentBody d-flex flex-column justify-content-start">
            <Container className="mt-5">
                {/*TODO: Podmienić imię użytkownika na wartość z kontrolera.*/}
                <Greeting userName={props.user.user.userName}/>
                <Tabs/>
            </Container>
    </section>
);

const mapStateToProps = state => ({
    user: state.user
});

export default connect(mapStateToProps)(UserPanel);

