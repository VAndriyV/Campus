import React, {Component} from 'react';
import { Form, Button, FormGroup, Label, Input } from 'reactstrap';
import Select from '../../../select';

export default class CreateLectorSubjectForm extends Component{
    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(){

    }

    render(){
        const {lectors, subjects, lessonTypes, lectorSubject} = this.props;

        return(<Form onSubmit={this.onSubmit} >  
            <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={lectorSubject.id} />
            </FormGroup>         
            <FormGroup>
                <Select label={"Lector"} name={"lectorId"} options = {lectors} textProperties={['firstName','lastName','patronymic']} initValue = {lectorSubject.lectorId}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Subject"} name={"subjectId"} options = {subjects} initValue={lectorSubject.subjectId}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Lesson type"} name={"lessonTypeId"} options = {lessonTypes} initValue={lectorSubject.lessonTypeId}/>
            </FormGroup>

            <Button outline color="secondary">Submit</Button>
        </Form>)
    }
}