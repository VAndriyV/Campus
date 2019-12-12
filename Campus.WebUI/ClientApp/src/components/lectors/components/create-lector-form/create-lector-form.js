import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';

export default class CreateLectorForm extends Component{ 
    state={
        firstName:'',
        lastName:'',
        patronymic:'',
        academicRankId:0,
        academicDegreeId:0,
        email:'',
        phoneNumber:''
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

    onSubmit(e){
        e.preventDefault();

        const {firstName,lastName,patronymic,academicRankId,
               academicDegreeId,email,phoneNumber} = this.state;
        this.props.onSubmit({firstName,lastName,patronymic,academicRankId,
            academicDegreeId,email,phoneNumber});
    }

    render(){
        const {academicRanks, academicDegrees} = this.props;

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="firstName">First name</Label>
                <Input type="text" name="firstName" id="firstName" placeholder="First name" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="lastName">Last name</Label>
                <Input type="text" name="lastName" id="lastName" placeholder="Last name" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="patronymic">Patronymic</Label>
                <Input type="text" name="patronymic" id="patronymic" placeholder="Patronymic" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Academic rank"} name={"academicRankId"} options = {academicRanks} onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Academic degree"} name={"academicDegreeId"} options = {academicDegrees} onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="email">Email</Label>
                <Input type="text" name="email" id="email" placeholder="Email" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="phoneNumber">Phone number</Label>
                <Input type="text" name="phoneNumber" id="phoneNumber" placeholder="Phone number" onChange={this.handleChange}/>
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
}