import React from 'react';
import { connect } from 'react-redux';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

class NavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light >
          <Container>
            <NavbarBrand tag={Link} to="/">Library</NavbarBrand>
            <NavbarToggler onClick={this.toggle} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                        <ul className="navbar-nav flex-grow">
                            {this.props.user.isLogged && this.props.user.role !== "admin" &&
                                <NavItem>
                                    <NavLink tag={Link} className="btn btn-sm" to="/">Home</NavLink>
                                </NavItem>
                            }
                            {this.props.user.isLogged && this.props.user.role === "admin" &&
                                <NavItem>
                                    <NavLink tag={Link} className="btn btn-sm" to="/admin">Admin</NavLink>
                                </NavItem>
                            }
                            <NavItem>
                                {this.props.user.isLogged && this.props.user.role !== "admin" &&
                                    <NavLink tag={Link} className="btn btn-sm" to="/panel">Twoje konto</NavLink>
                                }
                            </NavItem>
                            {!this.props.user.isLogged &&
                                <NavItem>
                                    <NavLink tag={Link} className="btn btn-outline-success btn-sm ml-3 font-weight-bold text-success" to="/login">Logowanie</NavLink>
                                </NavItem>
                            }
                            {!this.props.user.isLogged &&
                                <NavItem>
                                    <NavLink tag={Link} className="btn btn-outline-secondary ml-3 btn-sm text-secondary" to="/register">Rejestracja</NavLink>
                                </NavItem>
                            
                            }
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}

const mapStateToProps = state => ({
    user: state.user.user
});

export default connect(mapStateToProps)(NavMenu);
