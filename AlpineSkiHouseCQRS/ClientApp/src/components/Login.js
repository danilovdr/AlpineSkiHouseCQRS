import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { url } from '../Configuration';

import { Card, CardHeader, CardBody, CardFooter, Button, InputGroup, Label, Input } from 'reactstrap';

const Login = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const login = () => {

    };

    return (
        <Card>
            <CardHeader>
                <h4>Вход</h4>
            </CardHeader>
            <CardBody>
                <InputGroup>
                    <Label>
                        Email
                        <Input onChange={e => setEmail(e.target.value)}/>
                    </Label>
                </InputGroup>
                <InputGroup>
                    <Label>
                        Password
                        <Input type="password" onChange={e => setPassword(e.target.value)}/>
                    </Label>
                </InputGroup>
            </CardBody>
            <CardFooter>
                <Button onClick={login}>Войти</Button>
            </CardFooter>
        </Card>
    )
}

export default Login;