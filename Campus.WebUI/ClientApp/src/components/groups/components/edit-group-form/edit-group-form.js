import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';

export default class EditGroupForm extends Component{   
    state={
        id:0,
        name:'',
        specialityId:0,
        educationalDegreeId:0,
        year:0,
        studentsCount:0
    }

    constructor(props){
        super(props);
        
        const {id,name,specialityId,educationalDegreeId,year,studentsCount} = props.group;
        this.state={id,name,specialityId,educationalDegreeId,year,studentsCount};

        this.onSubmit = this.onSubmit.bind(this);       
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e){   
        const {name,value} = e.target;        
        this.setState({[name]: value });        
    }
    
    onSubmit(e) {
        e.preventDefault();

        const {id,name,specialityId,educationalDegreeId,year,studentsCount} = this.state;
        this.props.onSubmit({id,name,specialityId,educationalDegreeId,year,studentsCount});
    }

    render(){
        const {specialities, educationalDegrees} = this.props;       
        const {id,name,specialityId,educationalDegreeId,year,studentsCount} = this.state;

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={id} />
            </FormGroup>
            <FormGroup>
                <Label for="name">Group name</Label>
                <Input type="text" name="name" id="name" defaultValue={name} placeholder="Group name" />
            </FormGroup>
            <FormGroup>
                <Select label={"Speciality"} name={"specialityId"} options = {specialities} initValue={specialityId}/>
            </FormGroup>
            <FormGroup>
                <Select label = {"Educational degree"} name={"educationalDegreeId"} options = {educationalDegrees} initValue = {educationalDegreeId}/> 
            </FormGroup>           
            <FormGroup>
                <Label for="year">Year</Label>
                <Input type="number" name="year" id="year" defaultValue = {year} placeholder="Year" />
            </FormGroup>
            <FormGroup>
                <Label for="studentsCount">Students count</Label>
                <Input type="number" name="studentsCount" id="studentsCount" defaultValue={studentsCount} placeholder="Students count"/>
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
};
