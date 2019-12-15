import React, {Component} from 'react';
import EditLectorSubjectForm from '../../components/edit-lector-subject-form';
import Spinner from '../../../spinner';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class EditLectorSubjectPage extends Component{
    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    state={
        lectorSubject:null,
        lectors:[],
        subjects:[],
        lessonTypes:[],
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        loading:true
    };

    componentDidMount(){
        this.fetchData();
    }

    fetchData() {
        const {id} = this.props.match.params;
        const {campusService} = this.props;

        Promise.all([
            campusService.getLectorSubject(id),            
            campusService.getAllLectors(),
            campusService.getAllSubjects(),
            campusService.getLessonTypes(),
        ])
        .then(([lectorSubject, {lectors},{subjects},{items}])=>{
            this.setState({
                lectorSubject: lectorSubject,
                lectors:lectors,
                subjects:subjects,
                lessonTypes:items,
                loading:false
            });
        });
    }

    onSubmit(lectorSubject){
        this.setState({
            operationSuccessful: false,         
            hasError: false,
            errorObj: null
        });

        this.props.campusService.updateLectorSubject(lectorSubject)
        .then(() => {
            this.setState({
                operationSuccessful: true               
            })
        })
        .catch(err => {               
            if (err.status === 400 || err.status=== 409) {
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
        const {lectors, subjects, lessonTypes, lectorSubject, loading,hasError, errorObj,
            operationSuccessful} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<EditLectorSubjectForm lectorSubject={lectorSubject} lectors={lectors} 
                subjects={subjects} lessonTypes={lessonTypes} onSubmit={this.onSubmit}
                hasError={hasError} errorObj={errorObj}/>}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Record is successfully updated.</h5>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditLectorSubjectPage);