import React, { Component } from 'react';
import CreateLessonForm from '../../components/create-lesson-form';
import Spinner from '../../../spinner';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class CreateLessonPage extends Component {
    constructor(props) {
        super(props)

        this.updateSubjectsList = this.updateSubjectsList.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    state = {
        groups: [],
        lectors: [],
        subjects: [],
        lessonTypes: [],
        lectorId: 0,
        lessonTypeId: 0,
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        loading: true
    };

    componentDidMount() {
        this.fetchData();
    }

    componentDidUpdate(prevProps, prevState) {
        const { lectorId, lessonTypeId } = this.state;
        if (lectorId && lessonTypeId &&
            (lectorId != prevState.lectorId || lessonTypeId != prevState.lessonTypeId)) {

            const { campusService } = this.props;
            campusService.getLectorsSubjectsByLessonType(lectorId, lessonTypeId)
                .then(({ lectorsSubjects }) => {
                    this.setState({
                        ...this.state,
                        subjects: lectorsSubjects
                    });
                });
        }
    }

    fetchData() {
        const { campusService } = this.props;

        Promise.all([
            campusService.getAllLectors(),
            campusService.getAllGroups(),
            campusService.getLessonTypes(),
        ]).then(([{ lectors }, { groups }, { items }]) => {
            this.setState({
                lectors: lectors,
                groups: groups,
                lessonTypes: items,
                loading: false
            });
        });
    }

    updateSubjectsList(e) {
        const { name, value } = e.target;

        this.setState({
            [name]: value
        });
    }

    onSubmit(lesson) {
        this.setState({
            operationSuccessful: false,         
            hasError: false,
            errorObj: null
        });

        this.props.campusService.createLesson(lesson)
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

    render() {
        const { lectors, groups, lessonTypes, subjects, loading, hasError, errorObj,
            operationSuccessful } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <CreateLessonForm subjects={subjects}
                        lectors={lectors} groups={groups}
                        lessonTypes={lessonTypes} updateSubject={this.updateSubjectsList}
                        onSubmit={this.onSubmit} hasError={hasError} errorObj={errorObj} />}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Lesson is successfully added.</h5>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateLessonPage);