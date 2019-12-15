import React from 'react';
import { connect } from 'react-redux';
import {Button, NavLink} from 'reactstrap';
import GitHubIcon from '@material-ui/icons/GitHub';
import './Main.css';

const Home = props => (
    <div className="h-100 d-flex flex-column justify-content-center text-white">
        <div>
            <h1>Biblioteka wirtualna</h1>
            <span className="d-block mb-4">Nowa biblioteka w ASP.NET Core i React.js</span>
            <NavLink className="px-0" href="https://github.com/">
                <Button color="warning font-weight-bold d-flex align-items-center justify-content-center shadow" target="_blank">
                    <GitHubIcon className="mr-2 small"/>
                    <span>Zobacz na GitHub</span>
                </Button>
            </NavLink>
        </div>
    </div>
);

export default connect()(Home);

