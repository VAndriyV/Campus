import React, {Component} from 'react';
import CreateAttendanceForm from '../../components/create-attendance-form';
import Spinner from '../../../spinner';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class CreateAttendancePage extends Component{
    constructor(props) {
        super(props)

        this.updateLessonsList = this.updateLessonsList.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    lectorId = 1;
    state={
        groups:[],
        lessons:[],
        groupId:0,
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        loading:true
    };

    componentDidMount() {
        this.fetchData();
    }

    componentDidUpdate(prevProps, prevState) {
        const { groupId } = this.state;
        if (groupId && prevState.groupId != groupId) {
            const { campusService } = this.props;
            campusService.getLessonsByLectorAndGroup(this.lectorId, groupId)
                .then(({ lessons }) => {
                    this.setState({
                        ...this.state,
                        lessons: lessons
                    });
                });
        }
    }

    fetchData(){
        const {campusService} = this.props;       

        Promise.all([
            campusService.getLectorsGroups(this.lectorId),
            campusService.getWeatherTypes()            
        ]).then(([{ groups }, { items }]) => {
            this.setState({                
                groups: groups,
                weatherTypes:items,              
                loading: false
            });
        });
    }

    updateLessonsList(e){
        const { name, value } = e.target;

        this.setState({           
            [name]: value
        });
    }

    onSubmit(attendance){
        console.log(attendance);
        this.props.campusService.createAttendance(attendance)
        .then(() => {
            this.setState({
                operationSuccessful: true
            })
        })
        .catch(err => {
            if (err.status === 400 || err.status === 409) {
                this.setState({
                    hasError: true,
                    errorObj: err
                });
            }
            else {
                throw err;
            }
        });
    }

    render(){
        const {loading, lessons, groups, weatherTypes,  hasError, errorObj} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <CreateAttendanceForm groups={groups}
                        lessons={lessons} updateLesson = {this.updateLessonsList}
                        weatherTypes = {weatherTypes}
                        onSubmit={this.onSubmit} hasError={hasError} errorObj={errorObj}/>}
                        {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Record is successfully added.</h5>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
} 

export default withCampusService(CreateAttendancePage);