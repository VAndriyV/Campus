import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import Select from '../../../select';
import ErrorsAlert from '../../../common/errors-alert';

export default class EditLectorForm extends Component{ 
    state={
        id:0,
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

        const {id,firstName,lastName,patronymic,
               academicDegreeId, academicRankId, email, phoneNumber} = props.lector;
        this.state = {id,firstName,lastName,patronymic,
            academicDegreeId, academicRankId, email, phoneNumber}; 
        this.onSubmit = this.onSubmit.bind(this);       
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e){   
        const {name,value} = e.target;        
        this.setState({[name]: value });        
    } 

    onSubmit(e){
        e.preventDefault();

        const {id,firstName,lastName,patronymic,academicRankId,
               academicDegreeId,email,phoneNumber} = this.state;
        this.props.onSubmit({id,firstName,lastName,patronymic,academicRankId,
            academicDegreeId,email,phoneNumber});
    }

    render(){    
        const {academicRanks, academicDegrees} = this.props;
        const {id,firstName,lastName,patronymic,
            academicDegreeId, academicRankId, email, phoneNumber,
            hasError, errorObj} = this.state;

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={id} />
            </FormGroup>
            <FormGroup>
                <Label for="firstName">First name</Label>
                <Input type="text" name="firstName" id="firstName" defaultValue={firstName} placeholder="First name" />
            </FormGroup>
            <FormGroup>
                <Label for="lastName">Last name</Label>
                <Input type="text" name="lastName" id="lastName" defaultValue={lastName} placeholder="Last name" />
            </FormGroup>
            <FormGroup>
                <Label for="patronymic">Patronymic</Label>
                <Input type="text" name="patronymic" id="patronymic" defaultValue={patronymic} placeholder="Patronymic" />
            </FormGroup>
            <FormGroup>
                <Select label={"Academic rank"} name={"academicRankId"} options = {academicRanks} initValue={academicRankId}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Academic degree"} name={"academicDegreeId"} options = {academicDegrees} initValue={academicDegreeId}/>
            </FormGroup>
            <FormGroup>
                <Label for="email">Email</Label>
                <Input type="text" name="email" id="email" defaultValue={email} placeholder="Email" />
            </FormGroup>
            <FormGroup>
                <Label for="phoneNumber">Phone number</Label>
                <Input type="text" name="phoneNumber" id="phoneNumber" defaultValue={phoneNumber} placeholder="Phone number" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
            {hasError?<ErrorsAlert error={errorObj}/>:null} 
        </Form>);
    }
}