import React, {Component} from 'react';
import { Form, FormGroup, Label, Input, Button, Col } from 'reactstrap';
import Select from '../../../select';
import DatePicker from 'react-datepicker';

export default class CreateAttendanceForm extends Component{  

    state={
        dateObj:new Date(),
        groupId:0,
        lectorSubjectId:0,
        studentsCount:0,
        weatherTypeId:0
    }

    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.updateLesson = this.updateLesson.bind(this);       
    }

    onSubmit(e){
        e.preventDefault();
        const {groupId,dateObj,lectorSubjectId,studentsCount,weatherTypeId} = this.state;
        const dayOfWeekId = dateObj.getDay()==0?7:dateObj.getDay();
        const date = dateObj.toISOString();        
        this.props.onSubmit({groupId,dayOfWeekId, date, lectorSubjectId,studentsCount,weatherTypeId});      
    }

    handleDateChange(value) {       
        this.setState({ dateObj: value});
    } 
    
    handleChange(e){
        const {name,value} = e.target;
        
        this.setState({[name]: value}); 
    }
    
    updateLesson(e){
        this.handleChange(e);

        this.props.updateLesson(e);
    }
    
    render(){      
        const {dateObj} = this.state;
        const {groups, lessons, weatherTypes} = this.props;
        
        return (<Form onSubmit={this.onSubmit} >
             <FormGroup>
                <Select label={"Group"} name={"groupId"} onChange={this.updateLesson} options = {groups}/>
            </FormGroup>
            <FormGroup>
                <Select label={"Lesson"} name={"lectorSubjectId"} onChange={this.handleChange} options = {lessons}/>
            </FormGroup>
            <FormGroup>
                <Label>Date</Label>
                <DatePicker dateFormat="yyyy/MM/dd" todayButton="Today" selected={dateObj} onChange={(event) => this.handleDateChange(event)} /> 
            </FormGroup>
            <FormGroup>
                <Select label={"Weather type"} name={"weatherTypeId"} onChange={this.handleChange} options = {weatherTypes}/>
            </FormGroup>
            <FormGroup>
                <Label for="studentsCount">Students count</Label>
                <Input type="number" name="studentsCount" id="studentsCount" onChange={this.handleChange} placeholder="Students count" />
            </FormGroup>
            <Button outline color="secondary">Submit</Button>
        </Form>);
    }
}