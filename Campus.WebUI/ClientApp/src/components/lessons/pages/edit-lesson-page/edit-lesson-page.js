import React, { Component } from 'react';
import EditLessonForm from '../../components/edit-lesson-form';
import Spinner from '../../../spinner';
import { Row, Col } from 'reactstrap';
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
        lectorId: undefined,
        lessonTypeId: undefined,
        lesson:null,
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
        const {id} = this.props.match.params;
        const { campusService } = this.props;

        Promise.all([
            campusService.getLesson(id),
            campusService.getAllLectors(),
            campusService.getAllGroups(),
            campusService.getLessonTypes(),
        ]).then(([lesson, { lectors }, { groups }, { items }]) => {
            this.setState({
                lesson:lesson,
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

    onSubmit(data) {
        this.props.campusService.createLesson(data);
    }

    render() {
        const { lectors, groups, lessonTypes, subjects, lesson, loading } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <EditLessonForm subjects={subjects}
                        lectors={lectors} groups={groups}
                        lessonTypes={lessonTypes} lesson={lesson}
                        updateSubject={this.updateSubjectsList} 
                        onSubmit={this.onSubmit}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditLessonPage);