import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import ErrorsAlert from '../../../common/errors-alert';

export default class CreateSpecialityForm extends Component {
    state={
        name:'',
        code:0
    };

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

        const {name,code} = this.state;        
        this.props.onSubmit({name,code});
    }

    render() {
        const {hasError, errorObj} = this.props;

        return (<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Label for="name">Speciality name</Label>
                <Input type="text" name="name" id="name" placeholder="Speciality name" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="code">Code</Label>
                <Input type="number" name="code" id="code" placeholder="Code" onChange={this.handleChange}/>
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
            {hasError?<ErrorsAlert error={errorObj}/>:null}
        </Form>);
    };
};