import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Container, Row, Col, Card, CardHeader, CardBody, CardFooter, Button, InputGroup, Label, Input } from 'reactstrap';
import Register from './components/Register';
import Login from './components/Login';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Container>
        <Row className="mt-5">
          <Col xs={5}>
            <Register />
          </Col>
          <Col xs={5}>
            <Login />
          </Col>
        </Row>
      </Container >
    );
  }
}
