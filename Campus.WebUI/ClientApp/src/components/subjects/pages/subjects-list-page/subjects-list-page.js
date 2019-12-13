import React, { Component } from 'react';
import SubjectsList from '../../components/subjects-list';
import Spinner from '../../../spinner/';
import { Row, Col } from 'reactstrap';
import CreateNewLink from '../../../common/create-new-link';
import withCampusService from '../../../hoc/with-campus-service';
import Modal from '../../../common/modal';

class SubjectsListPage extends Component {
    constructor(props){
        super(props);

        this.onDelete = this.onDelete.bind(this);
        this.toggle = this.toggle.bind(this);
    }

    state = {
        subjects: [],
        hasError:false,
        error:'',
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
        this.props.campusService.deleteSubject(id)
        .then(() => this.removeSubjectFromList(id))
        .catch(err=>this.showModal(err));
    }

    removeSubjectFromList(id){
        this.setState({subjects: this.state.subjects.filter(function(subject) { 
            return subject.id !==id
        })});
    }

    showModal(err){
        this.setState({
            hasError:true,
            error:err.error
        })
    }

    toggle(){
        this.setState({
            hasError:!this.state.hasError
        });
    }

    render() {
        const { subjects, loading, error, hasError } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <React.Fragment>
                        <CreateNewLink to={'/subjects/new'} />
                        <SubjectsList subjects={subjects} onDelete={this.onDelete}/>
                        <Modal header='An error has occured while deleting subject' body = {error} 
                            modal = {hasError} toggle={this.toggle}/>
                    </React.Fragment>}
            </Col>
        </Row>)
    }
}

export default withCampusService(SubjectsListPage);