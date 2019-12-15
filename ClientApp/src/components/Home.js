import React from 'react';
import { connect } from 'react-redux';
import {Button, NavLink} from 'reactstrap';
import GitHubIcon from '@material-ui/icons/GitHub';
import DevicesOtherIcon from '@material-ui/icons/DevicesOther';
import './Main.css';
import { Container } from 'reactstrap';

import HomeBackground from '../images/home-bg.jpg'; 
var sectionStyle = {
  width: "100%",
  backgroundImage: "url(" + HomeBackground + ")",
  backgroundPosition: 'center 60%',
  backgroundSize: 'cover',
  backgroundRepeat: 'no-repeat'
};

const Home = props => (
    <section style={sectionStyle} className="documentBody d-flex flex-column justify-content-center">
        <div className="h-100 d-flex flex-column justify-content-center text-white">
            <Container>
                <div>
                    <h1>Biblioteka wirtualna</h1>
                    <span className="d-block mb-4">Nowa biblioteka w ASP.NET Core i React.js</span>
                    <div className="d-flex flex-row">
                        {/*TODO: Podmienić na prawdziwy link.*/}
                        <NavLink className="px-0" href="https://github.com/">
                            <Button color="warning font-weight-bold d-inline-flex align-items-center justify-content-center shadow" target="_blank">
                                <GitHubIcon className="mr-2 small"/>
                                <span>Zobacz na GitHub</span>
                            </Button>
                        </NavLink>

                        {/*TODO: Podmienić na prawdziwy link.*/}
                        <NavLink className="px-0 ml-3" href="http://ami.responsivedesign.is/">
                            <Button color="success font-weight-bold d-inline-flex align-items-center justify-content-center shadow" target="_blank">
                                <DevicesOtherIcon className="mr-2 small"/>
                                <span>Sprawdź RWD</span>
                            </Button>
                        </NavLink>
                    </div>
                </div>
            </Container>
        </div>
    </section>
);

export default connect()(Home);

