import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';

export default class CreateSpecialityForm extends Component {

    onSubmit() {

    }

    render() {

        return (<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="name">Speciality name</Label>
                <Input type="text" name="name" id="name" placeholder="Speciality name" />
            </FormGroup>
            <FormGroup>
                <Label for="code">Code</Label>
                <Input type="number" name="name" id="name" placeholder="code" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    };
};