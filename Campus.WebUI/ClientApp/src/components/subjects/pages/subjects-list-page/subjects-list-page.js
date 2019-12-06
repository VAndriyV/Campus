import React, {Component} from 'react';
import SubjectsList from '../../components/subjects-list';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class SubjectsListPage extends Component{
    state = {
        subjects:[],
        loading:true
    }

    componentDidMount(){
        this.fetchSubjects();
    }

    fetchSubjects(){
        this.props.campusService
            .getAllSubjects()
            .then((res)=>{               
                this.setState({
                    subjects:res.subjects,
                    loading:false
                });
            });
    }

    render(){
        const {subjects, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<SubjectsList subjects={subjects}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(SubjectsListPage);