import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import ErrorsAlert from '../../../common/errors-alert';

export default class CreateSubjectForm extends Component {
    state={
        id:0,
        name:''
    }

    constructor(props){
        super(props);

        const {id,name}=props.subject; 

        this.state = {id,name};

        this.onSubmit = this.onSubmit.bind(this);       
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e){   
        const {name,value} = e.target;        
        this.setState({[name]: value });        
    } 

    onSubmit(e) {
        e.preventDefault();

        const {id,name}= this.state;             
        this.props.onSubmit({id,name});
    }

    render() {
        const { id,name, hasError, errorObj } = this.state;       

        return (<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={id} />
            </FormGroup>
            <FormGroup>
                <Label for="name">Subject name</Label>
                <Input type="text" name="name" id="name" defaultValue={name} placeholder="Subject name" onChange={this.handleChange} />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
            {hasError?<ErrorsAlert error={errorObj}/>:null} 
        </Form>);
    };
};