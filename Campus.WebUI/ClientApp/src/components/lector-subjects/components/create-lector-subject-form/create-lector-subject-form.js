import React, {Component} from 'react';
import { Form, Button, FormGroup } from 'reactstrap';
import Select from '../../../select';

export default class CreateLectorSubjectForm extends Component{

    onSubmit(){

    }

    render(){
        const {lectors, subjects, lessonTypes, initLectorId} = this.props;        

        return(<Form onSubmit={this.onSubmit} >           
            <FormGroup>
                <Select label={"Lector"} name={"lectorId"} textProperties={['firstName','lastName','patronymic']} options = {lectors} initValue = {initLectorId}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Subject"} name={"subjectId"} options = {subjects}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Lesson type"} name={"lessonTypeId"} options = {lessonTypes}/>
            </FormGroup>

            <Button outline color="secondary">Submit</Button>
        </Form>)
    }
}