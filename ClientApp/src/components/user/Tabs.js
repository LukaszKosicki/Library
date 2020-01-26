import React, { useState } from 'react'; 
import classnames from 'classnames';
import { TabContent, TabPane, Nav, NavItem, NavLink, Card, Button, CardTitle, CardText, Row, Col, Container, Table } from 'reactstrap';
import { connect } from 'react-redux';
import { isNotLogged } from "../../store/actions/user";
import { withRouter } from "react-router";
import Books from "../user/Books";

const Tabs = props => {
    const [activeTab, setActiveTab] = useState('1');
    const toggle = tab => {
      if(activeTab !== tab) setActiveTab(tab);
    }

    function deleteUser(userId) {
       
        fetch('api/user/' + userId, {
            method: 'delete'
        })
            .then(resp => resp.json())
            .then(resp => {
                if (resp.deleteResult) {
                    alert(resp.msg)
                    props.logout();
                    props.history.push("/login");
                } else {
                    alert(resp.msg);
                }
            })
    }

    return (
        <div>
        <Nav tabs>
          <NavItem>
            <NavLink
              className={classnames({ active: activeTab === '1' })}
              onClick={() => { toggle('1'); }}
            >
              Wypożyczenia
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink
              className={classnames({ active: activeTab === '2' })}
              onClick={() => { toggle('2'); }}
            >
              Twoje konto
            </NavLink>
                </NavItem>
                <NavItem>
                    <NavLink
                        className={classnames({ active: activeTab === '3' })}
                        onClick={() => { toggle('3'); }}
                    >
                        Książki
            </NavLink>
                </NavItem>
        </Nav>
        <TabContent activeTab={activeTab}>
          <TabPane tabId="1">
            <Row>
              <Col sm="12">
          
              </Col>
            </Row>
          </TabPane>
          <TabPane tabId="2">
            <Row>
              <Col sm="12">
                            <Card body>
                                <Button onClick={() => { deleteUser(props.user.user.id) }} type="button" color="danger">Usuń konto</Button>
                </Card>
              </Col>
            </Row>
                </TabPane>
                <TabPane tabId="3">
                    <Row>
                        <Col sm="12">
                            <Books/>
                        </Col>
                    </Row>
                </TabPane>
        </TabContent>
      </div>
    )
}

const mapStateToProps = state => ({
    user: state.user
});

const mapDispatchToProps = dispatch => {
    return {
        logout: () => dispatch(isNotLogged())
    }
};

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(Tabs));