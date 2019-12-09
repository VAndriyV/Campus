import React, {Component} from 'react';
import { Form, Button, FormGroup } from 'reactstrap';
import Select from '../../../select';

export default class CreateLessonForm extends Component{
    
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
        const {groups, lectors, lessonTypes, subjects} = this.props;        
        const {groupId} = this.state;       

        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Select label={"Group"} initValue={groupId} name={"groupId"} onChange={this.handleChange} options = {groups}/>
            </FormGroup>             
            <FormGroup>
                <Select label={"Lector"} name={"lectorId"} textProperties={['firstName','lastName','patronymic']} onChange={this.updateSubject} options = {lectors}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Lesson type"} name={"lessonTypeId"} onChange={this.updateSubject} options = {lessonTypes}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Subject"} name={"subjectId"} onChange={this.handleChange} options = {subjects}/>
            </FormGroup>           

            <Button outline color="secondary">Submit</Button>
        </Form>)
    }
}