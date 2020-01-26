import React, { useState } from 'react';
import { connect } from 'react-redux';
import { TabContent, TabPane, Nav, NavItem, NavLink, Card, Button, CardTitle, CardText, Row, Col, Container, Table } from 'reactstrap';
import classnames from 'classnames';
import Greeting from '../common/Greeting';
import Users from "./Users";
import Books from "./Books";
import AddBook from "./AddBook";
import BookLoans from "./BookLoans";
import Categories from "./Categories";
import Author from "./Author";
import BookZwroc from "../admin/zwroc";
import BookZwrot from "../admin/zwrocone";

const Tabs = props => {

        const [activeTab, setActiveTab] = useState('1');
        const toggle = tab => {
            if (activeTab !== tab) setActiveTab(tab);
        }

        return (
            <div>
                <Nav tabs>
                    <NavItem>
                        <NavLink
                            className={classnames({ active: activeTab === '1' })}
                            onClick={() => { toggle('1'); }}
                        >
                            Użytkownicy
            </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({ active: activeTab === '2' })}
                            onClick={() => { toggle('2'); }}
                        >
                            Książki
            </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({ active: activeTab === '3' })}
                            onClick={() => { toggle('3'); }}
                        >
                            Nowa książka
            </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({ active: activeTab === '4' })}
                            onClick={() => { toggle('4'); }}
                        >
                            Prośby 
            </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({ active: activeTab === '5' })}
                            onClick={() => { toggle('5'); }}
                        >
                            Kategorie
            </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({ active: activeTab === '6' })}
                            onClick={() => { toggle('6'); }}
                        >
                          Autorzy
            </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({ active: activeTab === '7' })}
                            onClick={() => { toggle('7'); }}
                        >
                            Zwroty
            </NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink
                            className={classnames({ active: activeTab === '8' })}
                            onClick={() => { toggle('8'); }}
                        >
                            Zwrócone
            </NavLink>
                    </NavItem>
                </Nav>
                <TabContent activeTab={activeTab}>
                    <TabPane tabId="1">
                        <Row>
                            <Col sm="12">
                                <Users/>
                            </Col>
                        </Row>
                    </TabPane>
                    <TabPane tabId="2">
                        <Row>
                            <Col sm="12">
                                <Books/>
                            </Col>
                        </Row>
                    </TabPane>
                    <TabPane tabId="3">
                        <Row>
                            <Col sm="12">
                                <AddBook />
                            </Col>
                        </Row>
                    </TabPane>
                    <TabPane tabId="4">
                        <Row>
                            <Col sm="12">
                                <BookLoans />
                            </Col>
                        </Row>
                    </TabPane>
                    <TabPane tabId="5">
                        <Row>
                            <Col sm="12">
                                <Categories />
                            </Col>
                        </Row>
                    </TabPane>
                    <TabPane tabId="6">
                        <Row>
                            <Col sm="12">
                                <Author />
                            </Col>
                        </Row>
                    </TabPane>
                    <TabPane tabId="7">
                        <Row>
                            <Col sm="12">
                                <BookZwroc />
                            </Col>
                        </Row>
                    </TabPane>
                    <TabPane tabId="8">
                        <Row>
                            <Col sm="12">
                                <BookZwrot />
                            </Col>
                        </Row>
                    </TabPane>
                </TabContent>
            </div>
            );
}

const AdminPanel = props => (
    <section className="documentBody d-flex flex-column justify-content-start">
        <Container className="mt-5">
            {/*TODO: Podmienić imię użytkownika na wartość z kontrolera.*/}
            <Greeting userName={props.user.user.userName} />
            <Tabs />
        </Container>
    </section>
);

const mapStateToProps = state => ({
    user: state.user
});

export default connect(mapStateToProps)(AdminPanel);