import React, {Component} from 'react';
import { Form, Button, FormGroup, Label, Input } from 'reactstrap';
import Select from '../../../select';

export default class EditLessonForm extends Component{
    
    state={
        groupId:undefined,
        lectorId:undefined,
        lessonTypeId:undefined,
        subjectId:undefined
    };
    
    constructor(props){
        super(props);

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
        
        this.props.onSubmit(this.state);
    }
    

    render(){
        const {groups, lectors, lessonTypes, subjects, lesson} = this.props;

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
        </Form>)
    }
}