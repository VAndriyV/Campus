import React, {Component} from 'react';
import { Form, Button, FormGroup } from 'reactstrap';
import Select from '../../../select';
import ErrorsAlert from '../../../common/errors-alert';

export default class CreateLessonForm extends Component{    
    state={
        groupId:0,
        lectorId:0,
        lessonTypeId:0,
        subjectId:0
    };
    
    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
        this.updateSubject = this.updateSubject.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e){   
        const {name,value} = e.target;        
        this.setState({[name]: value });        
    }   
    
    updateSubject(e){
        this.handleChange(e);
        this.props.updateSubject(e);
    }

    onSubmit(e){
        e.preventDefault();

        const {groupId, lectorId, lessonTypeId, subjectId} = this.state;
        this.props.onSubmit({groupId, lectorId, lessonTypeId, subjectId});
    }    

    render(){
        const {groups, lectors, lessonTypes, subjects, hasError, errorObj} = this.props;       
      
        return(<Form onSubmit={this.onSubmit} >
            <FormGroup>
                <Select label={"Group"} name={"groupId"} onChange={this.handleChange} options = {groups}/>
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
            {hasError?<ErrorsAlert error={errorObj}/>:null}
            <Button outline color="secondary">Submit</Button>
        </Form>)
    }
}