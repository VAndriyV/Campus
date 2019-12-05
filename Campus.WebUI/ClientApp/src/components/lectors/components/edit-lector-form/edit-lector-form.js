import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';

export default class EditLectorForm extends Component{
    componentDidMount(){

    }

    onSubmit(){

    }

    render(){    
        const {lector,academicRanks, academicDegrees} = this.props;

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={lector.id} />
            </FormGroup>
            <FormGroup>
                <Label for="firstName">First name</Label>
                <Input type="text" name="firstName" id="firstName" defaultValue={lector.firstName} placeholder="First name" />
            </FormGroup>
            <FormGroup>
                <Label for="lastName">Last name</Label>
                <Input type="text" name="lastName" id="lastName" defaultValue={lector.lastName} placeholder="Last name" />
            </FormGroup>
            <FormGroup>
                <Label for="patronymic">Patronymic</Label>
                <Input type="text" name="patronymic" id="patronymic" defaultValue={lector.patronymic} placeholder="Patronymic" />
            </FormGroup>
            <FormGroup>
                <Select label={"Academic rank"} name={"academicRankId"} options = {academicRanks} initValue={lector.academicRankId}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Academic degree"} options = {academicDegrees} initValue={lector.academicDegreeId}/>
            </FormGroup>
            <FormGroup>
                <Label for="email">Email</Label>
                <Input type="text" name="email" id="email" defaultValue={lector.email} placeholder="Email" />
            </FormGroup>
            <FormGroup>
                <Label for="phoneNumber">Phone number</Label>
                <Input type="text" name="phoneNumber" id="phoneNumber" defaultValue={lector.phoneNumber} placeholder="Phone number" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
}