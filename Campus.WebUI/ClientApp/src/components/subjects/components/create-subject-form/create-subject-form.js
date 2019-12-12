﻿import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';

export default class CreateSubjectForm extends Component {
    state={
        name:''
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
      
        this.props.onSubmit({name});
    }

    render() {
        return (<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="name">Subject name</Label>
                <Input type="text" name="name" id="name" placeholder="Subject name" onChange={this.handleChange} />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    };
};