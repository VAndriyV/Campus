import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';

export default class EditGroupForm extends Component{
    state = {
        specialities:[],
        educationDegrees:[]
    }
    
    componentDidMount(){

    }

    onSubmit() {

    }

    render(){
        const {specialities, educationDegrees} = this.state;
        const {group} = this.props;

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" value={group.id} />
            </FormGroup>
            <FormGroup>
                <Label for="name">Group name</Label>
                <Input type="text" name="name" id="name" value={group.name} placeholder="Group name" />
            </FormGroup>
            <Select name={"specialityId"} options = {specialities} initValue={group.specialityId}/>
            <Select name={"educationDegreeId"} options = {educationDegrees} initValue = {group.educationDegreeId}/>            
            <FormGroup>
                <Label for="year">Year</Label>
                <Input type="number" name="year" id="year" value = {group.year} placeholder="Year" />
            </FormGroup>
            <FormGroup>
                <Label for="studentsCount">Students count</Label>
                <Input type="number" name="studentsCount" id="studentsCount" value={group.studentsCount} placeholder="Students count"/>
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
};
