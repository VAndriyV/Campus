import React, {Component} from 'react';
import { Form, Button, FormGroup } from 'reactstrap';
import Select from '../../../select';
import ErrorsAlert from '../../../common/errors-alert';

export default class CreateLectorSubjectForm extends Component{
    state={
        lectorId:0,
        subjectId:0,
        lessonTypeId:0
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

    onSubmit(e){
        e.preventDefault();

        const {lectorId,subjectId,lessonTypeId}=this.state;
        this.props.onSubmit({lectorId,subjectId,lessonTypeId});
    }

    render(){
        const {lectors, subjects, lessonTypes, initLectorId, hasError, errorObj} = this.props;        

        return(<Form onSubmit={this.onSubmit} >           
            <FormGroup>
                <Select label={"Lector"} name={"lectorId"} textProperties={['firstName','lastName','patronymic']} 
                options = {lectors} initValue = {initLectorId} onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Subject"} name={"subjectId"} options = {subjects} onChange={this.handleChange}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Lesson type"} name={"lessonTypeId"} options = {lessonTypes} onChange={this.handleChange}/>
            </FormGroup>            
            <Button outline color="secondary">Submit</Button>
            {hasError?<ErrorsAlert error={errorObj}/>:null}
        </Form>)
    }
}