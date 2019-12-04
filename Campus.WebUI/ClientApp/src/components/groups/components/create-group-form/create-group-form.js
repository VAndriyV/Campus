import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';

export default class CreateGroupForm extends Component{
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

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="name">Group name</Label>
                <Input type="text" name="name" id="name" placeholder="Group name" />
            </FormGroup>
            <Select name={"specialityId"} options = {specialities}/>
            <Select name={"educationDegreeId"} options = {educationDegrees}/>
            <FormGroup>
                <Label for="year">Year</Label>
                <Input type="number" name="year" id="year" placeholder="Year" />
            </FormGroup>
            <FormGroup>
                <Label for="studentsCount">Students count</Label>
                <Input type="number" name="studentsCount" id="studentsCount" placeholder="Students count" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
};
