import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';

export default class EditSpecialityForm extends Component {

    onSubmit() {

    }

    render() {

        const { speciality } = this.props;

        return (<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" value={speciality.id} />
            </FormGroup>
            <FormGroup>
                <Label for="name">Speciality name</Label>
                <Input type="text" name="name" id="name" value={speciality.name} placeholder="Speciality name" />
            </FormGroup>
            <FormGroup>
                <Label for="code">Code</Label>
                <Input type="number" name="name" id="name" value={speciality.code} placeholder="code" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    };
};