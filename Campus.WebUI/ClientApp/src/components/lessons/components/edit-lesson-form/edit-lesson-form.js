import React, {Component} from 'react';
import { Form, Button, FormGroup, Label, Input } from 'reactstrap';
import Select from '../../../select';
import ErrorsAlert from '../../../common/errors-alert';

export default class EditLessonForm extends Component{
    
    state={
        id:0,
        groupId:0,
        lectorId:0,
        lessonTypeId:0,
        subjectId:0
    };
    
    constructor(props){
        super(props);

        const {id, groupId, lectorId, lessonTypeId, subjectId} = props.lesson;
        this.state = {id, groupId, lectorId, lessonTypeId, subjectId};
        
        this.onSubmit = this.onSubmit.bind(this);
        this.updateSubject = this.updateSubject.bind(this);
    }

    handleChange = (e) => {   
        const {name,value} = e.target;        
        this.setState({[name]: parseInt(value) });        
    }   
    
    updateSubject(e){
        this.handleChange(e);
        this.props.updateSubject(e);
    }

    onSubmit(e){
        e.preventDefault();        
        
        const {id, groupId, lectorId, lessonTypeId, subjectId} = this.state;
        this.props.onSubmit({id, groupId, lectorId, lessonTypeId, subjectId});
    }    

    render(){
        const {groups, lectors, lessonTypes, subjects, lesson, hasError, errorObj} = this.props;

        return(<Form onSubmit={this.onSubmit} >
             <FormGroup>
                <Label for="id" hidden>Id</Label>
                <Input type="hidden" name="id" id="id" defaultValue={lesson.id} />
            </FormGroup>
            <FormGroup>
                <Select label={"Group"} name={"groupId"} 
                onChange={this.handleChange} options = {groups} initValue={lesson.groupId}/>
            </FormGroup>             
            <FormGroup>
                <Select label={"Lector"} name={"lectorId"} textProperties={['firstName','lastName','patronymic']} 
                onChange={this.updateSubject} options = {lectors} initValue={lesson.lectorId}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Lesson type"} name={"lessonTypeId"} 
                onChange={this.updateSubject} options = {lessonTypes} initValue={lesson.lessonTypeId}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Subject"} name={"subjectId"} 
                onChange={this.handleChange} options = {subjects} initValue={lesson.subjectId}/>
            </FormGroup>           
            <Button outline color="secondary">Submit</Button>
            {hasError?<ErrorsAlert error={errorObj}/>:null}
        </Form>)
    }
}