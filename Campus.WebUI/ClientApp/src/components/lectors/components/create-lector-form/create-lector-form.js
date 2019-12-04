import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';

export default class CreateLectorForm extends Component{ 

    componentDidMount(){

    }

    onSubmit(){

    }

    render(){
        const {academicRanks, academicDegrees} = this.props;

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="firstName">First name</Label>
                <Input type="text" name="firstName" id="firstName" placeholder="First name" />
            </FormGroup>
            <FormGroup>
                <Label for="lastName">Last name</Label>
                <Input type="text" name="lastName" id="lastName" placeholder="Last name" />
            </FormGroup>
            <FormGroup>
                <Label for="patronymic">Patronymic</Label>
                <Input type="text" name="patronymic" id="patronymic" placeholder="Patronymic" />
            </FormGroup>
            <Select name={"academicRankId"} options = {academicRanks}/>
            <Select name={"academicDegreeId"} options = {academicDegrees}/>
            <FormGroup>
                <Label for="email">Email</Label>
                <Input type="text" name="email" id="email" placeholder="Email" />
            </FormGroup>
            <FormGroup>
                <Label for="phoneNumber">Phone number</Label>
                <Input type="text" name="phoneNumber" id="phoneNumber" placeholder="Phone number" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
}