import React, {Component} from 'react';
import ErrorsAlert from '../../../common/errors-alert';
import {FormGroup, Form, Label, Input, Button} from 'reactstrap';

export default class LoginForm extends Component{
    state={
        email:'',
        password:''
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

        const {email,password} = this.state;
        this.props.onSubmit({email,password});
    }

    render(){
        const {hasError, errorObj} = this.props;
        
        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="email">Email</Label>
                <Input type="email" name="email" id="email" placeholder="Email" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="password">Password</Label>
                <Input type="password" name="password" id="password" placeholder="Password" onChange={this.handleChange}/>
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
            {hasError?<ErrorsAlert error={errorObj}/>:null}
            </Form>
        );
    }
}