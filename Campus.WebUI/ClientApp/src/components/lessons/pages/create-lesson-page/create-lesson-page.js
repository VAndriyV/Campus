import React, { Component } from 'react';
import CreateLessonForm from '../../components/create-lesson-form';
import Spinner from '../../../spinner';
import { Row, Col } from 'reactstrap';
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

    onSubmit(data) {
        this.props.campusService.createLesson(data);
    }

    render() {
        const { lectors, groups, lessonTypes, subjects, loading } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <CreateLessonForm subjects={subjects}
                        lectors={lectors} groups={groups}
                        lessonTypes={lessonTypes} updateSubject={this.updateSubjectsList} 
                        onSubmit={this.onSubmit}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateLessonPage);