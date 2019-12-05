import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';

export default class EditGroupForm extends Component{   
    componentDidMount(){

    }

    onSubmit() {

    }

    render(){
        const {group, specialities, educationalDegrees} = this.props;       

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={group.id} />
            </FormGroup>
            <FormGroup>
                <Label for="name">Group name</Label>
                <Input type="text" name="name" id="name" defaultValue={group.name} placeholder="Group name" />
            </FormGroup>
            <FormGroup>
                <Select label={"Speciality"} name={"specialityId"} options = {specialities} initValue={group.specialityId}/>
            </FormGroup>
            <FormGroup>
                <Select label = {"Educational degree"} name={"educationalDegreeId"} options = {educationalDegrees} initValue = {group.educationalDegreeId}/> 
            </FormGroup>           
            <FormGroup>
                <Label for="year">Year</Label>
                <Input type="number" name="year" id="year" defaultValue = {group.year} placeholder="Year" />
            </FormGroup>
            <FormGroup>
                <Label for="studentsCount">Students count</Label>
                <Input type="number" name="studentsCount" id="studentsCount" defaultValue={group.studentsCount} placeholder="Students count"/>
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
};
