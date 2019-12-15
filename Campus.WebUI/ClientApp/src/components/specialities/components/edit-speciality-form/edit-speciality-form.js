import React, { Component } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import ErrorsAlert from '../../../common/errors-alert';

export default class EditSpecialityForm extends Component {
    state={
        id:0,
        name:'',
        code:0
    }

    constructor(props){
        super(props);

        const {id,name,code} = props.speciality;

        this.state={id,name,code};

        this.onSubmit = this.onSubmit.bind(this);       
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e){   
        const {name,value} = e.target;        
        this.setState({[name]: value });        
    }

    onSubmit(e) {
        e.preventDefault();

        const {id,code,name} = this.state;
        this.props.onSubmit({id,code,name});
    }

    render() {
        const { id,name,code } = this.state;       
        const {hasError, errorObj} = this.props;

        return (<Form onSubmit={this.onSubmit} >
            <Label for="id" hidden>Id</Label>
            <Input type="hidden" name="id" id="id" defaultValue={id} />
            <FormGroup>
                <Label for="name">Speciality name</Label>
                <Input type="text" name="name" id="name" defaultValue={name} placeholder="Speciality name" onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Label for="code">Code</Label>
                <Input type="number" name="code" id="code" defaultValue={code} placeholder="Code" onChange={this.handleChange}/>
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
            {hasError?<ErrorsAlert error={errorObj}/>:null}
        </Form>);
    };
};