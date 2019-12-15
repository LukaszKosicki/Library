import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import HomeBackground from '../images/home-bg.jpg'; 

var sectionStyle = {
  width: "100%",
  backgroundImage: "url(" + HomeBackground + ")",
  backgroundPosition: 'center 60%',
  backgroundSize: 'cover',
  backgroundRepeat: 'no-repeat'
};

export default props => (
  <div className="h-100">
    <NavMenu />
    <section style={sectionStyle} className="documentBody d-flex flex-column justify-content-center">
      <Container>
        {props.children}
      </Container>
    </section>
  </div>
);
