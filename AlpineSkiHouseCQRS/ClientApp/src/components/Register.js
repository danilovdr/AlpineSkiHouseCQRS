import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { url } from '../Configuration';
import { Card, CardHeader, CardBody, CardFooter, Button, InputGroup, Label, Input } from 'reactstrap';

const Register = () => {
    const [email, setEmail] = useState("");
    const [firstName, setFirstName] = useState("");
    const [middleName, setMiddleName] = useState("");
    const [secondName, setSecondName] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    const register = () => {

    };

    return (
        <Card>
            <CardHeader>
                <h4>Регистрация</h4>
            </CardHeader>
            <CardBody>
                <InputGroup>
                    <Label>
                        Email
                        <Input onChange={e => setEmail(e.target.value)} />
                    </Label>
                </InputGroup>
                <InputGroup>
                    <Label>
                        First name
                        <Input onChange={e => setFirstName(e.target.value)} />
                    </Label>
                </InputGroup>
                <InputGroup>
                    <Label>
                        Middle name
                        <Input onChange={e => setMiddleName(e.target.value)} />
                    </Label>
                </InputGroup>
                <InputGroup>
                    <Label>
                        Second name
                        <Input onChange={e => setSecondName(e.target.value)} />
                    </Label>
                </InputGroup>
                <InputGroup>
                    <Label>
                        Password
                        <Input onChange={e => setPassword(e.target.value)}/>
                    </Label>
                </InputGroup>
                <InputGroup>
                    <Label>
                        Confirm password
                        <Input onChange={e => setConfirmPassword(e.target.value)}/>
                    </Label>
                </InputGroup>
            </CardBody>
            <CardFooter>
                <Button onClick={register}>Зарегестрироваться</Button>
            </CardFooter>
        </Card>
    );
}

export default Register;