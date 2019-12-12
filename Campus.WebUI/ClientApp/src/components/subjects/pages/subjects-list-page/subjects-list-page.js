import React, { Component } from 'react';
import SubjectsList from '../../components/subjects-list';
import Spinner from '../../../spinner/';
import { Row, Col } from 'reactstrap';
import CreateNewLink from '../../../common/create-new-link';
import withCampusService from '../../../hoc/with-campus-service';

class SubjectsListPage extends Component {
    constructor(props){
        super(props);

        this.onDelete = this.onDelete.bind(this);
    }

    state = {
        subjects: [],
        loading: true
    }

    componentDidMount() {
        this.fetchSubjects();
    }

    fetchSubjects() {
        this.props.campusService
            .getAllSubjects()
            .then((res) => {
                this.setState({
                    subjects: res.subjects,
                    loading: false
                });
            });
    }

    onDelete(id){
        this.props.campusService.deleteSubject(id);
    }

    render() {
        const { subjects, loading } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <React.Fragment>
                        <CreateNewLink to={'/subjects/new'} />
                        <SubjectsList subjects={subjects} onDelete={this.onDelete}/>
                    </React.Fragment>}
            </Col>
        </Row>)
    }
}

export default withCampusService(SubjectsListPage);