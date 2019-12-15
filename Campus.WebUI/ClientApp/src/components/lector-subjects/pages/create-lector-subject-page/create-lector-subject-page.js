import React, {Component} from 'react';
import CreateLectorSubjectForm from '../../components/create-lector-subject-form';
import Spinner from '../../../spinner';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class CreateLectorSubjectPage extends Component{
    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    state={
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
        const {campusService} = this.props;       

        Promise.all([            
            campusService.getAllLectors(),
            campusService.getAllSubjects(),
            campusService.getLessonTypes(),
        ])
        .then(([{lectors},{subjects},{items}])=>{
            this.setState({
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

        this.props.campusService.createLectorSubject(lectorSubject)
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
        const {lectors, subjects, lessonTypes,loading, hasError, errorObj,
            operationSuccessful} = this.state;

        const {lectorId} = this.props.match.params;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<CreateLectorSubjectForm lectors={lectors} subjects={subjects} 
                lessonTypes={lessonTypes} initLectorId={lectorId} onSubmit={this.onSubmit} 
                hasError={hasError} errorObj={errorObj}/>}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Record is successfully added.</h5>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateLectorSubjectPage);