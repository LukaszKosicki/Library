import React, {useState} from 'react';
import { connect } from 'react-redux';
import './Main.css';
import { TabContent, TabPane, Nav, NavItem, NavLink, Card, Button, CardTitle, CardText, Row, Col, Container, Table } from 'reactstrap';
import classnames from 'classnames';
import Greeting from '../components/common/Greeting';


const BookshelfTable = () => {
  var today = new Date();
  return (
      <Table>
        <thead>
            <th>Okładka</th>
            <th>Tytuł</th>
            <th>Autor</th>
            <th>Wypożyczenie</th>
            <th>Oddanie</th>
        </thead>
        <tbody>
            <tr>
              <td align="center">X</td>
              <td align="left">Pan Tadeusz</td>
              <td align="left">Adam Mickiewicz</td>
              <td align="left">{today.toLocaleDateString("pl-PL")}</td>
              <td align="left">{today.toLocaleDateString("pl-PL")}</td>
            </tr>
            <tr>
              <td align="center">X</td>
              <td align="left">Pan Tadeusz</td>
              <td align="left">Adam Mickiewicz</td>
              <td align="left">{today.toLocaleDateString("pl-PL")}</td>
              <td align="left">{today.toLocaleDateString("pl-PL")}</td>
            </tr>
            <tr>
              <td align="center">X</td>
              <td align="left">Pan Tadeusz</td>
              <td align="left">Adam Mickiewicz</td>
              <td align="left">{today.toLocaleDateString("pl-PL")}</td>
              <td align="left">{today.toLocaleDateString("pl-PL")}</td>
            </tr>
        </tbody>
      </Table>
  )
}

const Tabs = props => {
    const [activeTab, setActiveTab] = useState('1');
    const toggle = tab => {
      if(activeTab !== tab) setActiveTab(tab);
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
        </Nav>
        <TabContent activeTab={activeTab}>
          <TabPane tabId="1">
            <Row>
              <Col sm="12">
                <BookshelfTable className="m-3" />
              </Col>
            </Row>
          </TabPane>
          <TabPane tabId="2">
            <Row>
              <Col sm="6">
                <Card body>
                  <CardTitle>Special Title Treatment</CardTitle>
                  <CardText>With supporting text below as a natural lead-in to additional content.</CardText>
                  <Button>Go somewhere</Button>
                </Card>
              </Col>
              <Col sm="6">
                <Card body>
                  <CardTitle>Special Title Treatment</CardTitle>
                  <CardText>With supporting text below as a natural lead-in to additional content.</CardText>
                  <Button>Go somewhere</Button>
                </Card>
              </Col>
            </Row>
          </TabPane>
        </TabContent>
      </div>
    )
    }

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

