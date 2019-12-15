import React, {Component} from 'react';
import { Form, Button, FormGroup, Label, Input } from 'reactstrap';
import Select from '../../../select';
import ErrorsAlert from '../../../common/errors-alert';

export default class CreateLectorSubjectForm extends Component{
    state={
        id:0,
        lectorId:0,
        subjectId:0,
        lessonTypeId:0
    }

    constructor(props){
        super(props);

        const {id,lectorId,subjectId,lessonTypeId} = props.lectorSubject;

        this.state={id,lectorId,subjectId,lessonTypeId};

        this.onSubmit = this.onSubmit.bind(this);       
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e){   
        const {name,value} = e.target;        
        this.setState({[name]: value });        
    }

    onSubmit(e){
        e.preventDefault();

        const {id,lectorId,subjectId,lessonTypeId}=this.state;
        this.props.onSubmit({id,lectorId,subjectId,lessonTypeId});
    }

    render(){
        const {lectors, subjects, lessonTypes, hasError, errorObj } = this.props;
        const {id,lectorId,subjectId,lessonTypeId} = this.state;

        return(<Form onSubmit={this.onSubmit} >  
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={id} onChange={this.handleChange}/>
            </FormGroup>         
            <FormGroup>
                <Select label={"Lector"} name={"lectorId"} options = {lectors} textProperties={['firstName','lastName','patronymic']}
                initValue = {lectorId} onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Subject"} name={"subjectId"} options = {subjects} initValue={subjectId} onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Lesson type"} name={"lessonTypeId"} options = {lessonTypes} initValue={lessonTypeId} onChange={this.handleChange}/>
            </FormGroup>
            {hasError?<ErrorsAlert error={errorObj}/>:null}
            <Button outline color="secondary">Submit</Button>
        </Form>)
    }
}