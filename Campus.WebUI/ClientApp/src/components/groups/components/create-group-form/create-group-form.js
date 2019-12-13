import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';

export default class CreateGroupForm extends Component{ 
    state={
        name:'',
        specialityId:0,
        educationalDegreeId:0,
        year:0,
        studentsCount:0
    }

    constructor(props){
        super(props);
        
        this.onSubmit = this.onSubmit.bind(this);       
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e){   
        const {name,value} = e.target;        
        this.setState({[name]: value });        
    }
    
    onSubmit(e) {
        e.preventDefault();

        const {name,specialityId,educationalDegreeId,year,studentsCount} = this.state;
        this.props.onSubmit({name,specialityId,educationalDegreeId,year,studentsCount});
    }

    render(){
        const {specialities, educationalDegrees} = this.props;

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="name">Group name</Label>
                <Input type="text" name="name" id="name" placeholder="Group name" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Speciality"} name={"specialityId"} options = {specialities} onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Educational degree"} name={"educationalDegreeId"} options = {educationalDegrees} onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="year">Year</Label>
                <Input type="number" name="year" id="year" placeholder="Year" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="studentsCount">Students count</Label>
                <Input type="number" name="studentsCount" id="studentsCount" placeholder="Students count" onChange={this.handleChange}/>
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
};
