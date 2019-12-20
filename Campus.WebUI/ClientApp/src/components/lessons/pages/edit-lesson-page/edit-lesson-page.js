import React, { Component } from 'react';
import EditLessonForm from '../../components/edit-lesson-form';
import Spinner from '../../../spinner';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class EditLessonPage extends Component {
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
        lesson: null,
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
        const { id } = this.props.match.params;
        const { campusService } = this.props;

        Promise.all([
            campusService.getLesson(id),
            campusService.getAllLectors(),
            campusService.getAllGroups(),
            campusService.getLessonTypes(),
        ])
            .then(([lesson, { lectors }, { groups }, { items }]) => {
                this.setState({
                    lesson: lesson,
                    lectors: lectors,
                    groups: groups,
                    lessonTypes: items,
                    loading: false
                });
            })
            .catch(err => {
                this.setState({
                    hasError: true,
                    errorObj: err
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

        this.props.campusService.updateLesson(lesson)
            .then(() => {
                this.setState({
                    operationSuccessful: true
                })
            })
            .catch(err => {
                this.setState({
                    hasError: true,
                    errorObj: err
                });
            });
    }

    render() {
        const { lectors, groups, lessonTypes, subjects, lesson, loading, hasError, errorObj,
            operationSuccessful } = this.state;
        if (hasError && !(errorObj.status === 400 || errorObj.status === 409)) {
            throw errorObj;
        }
        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <EditLessonForm subjects={subjects}
                        lectors={lectors} groups={groups}
                        lessonTypes={lessonTypes} lesson={lesson}
                        updateSubject={this.updateSubjectsList}
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

export default withCampusService(EditLessonPage);