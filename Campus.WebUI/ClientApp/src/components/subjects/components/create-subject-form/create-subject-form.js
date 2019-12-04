import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';

export default class CreateSubjectForm extends Component {

    onSubmit() {

    }

    render() {        

        return (<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="name">Subject name</Label>
                <Input type="text" name="name" id="name" placeholder="Subject name" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    };
};