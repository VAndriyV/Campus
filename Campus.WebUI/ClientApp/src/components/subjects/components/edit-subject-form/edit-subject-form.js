import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';

export default class CreateSubjectForm extends Component {

    onSubmit() {

    }

    render() {
        const { subject } = this.props;

        return (<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={subject.id} />
            </FormGroup>
            <FormGroup>
                <Label for="name">Subject name</Label>
                <Input type="text" name="name" id="name" defaultValue={subject.name} placeholder="Subject name" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    };
};