import React, {Component} from 'react';
import CreateLectorSubjectForm from '../../components/create-lector-subject-form';
import Spinner from '../../../spinner';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class CreateLectorSubjectPage extends Component{
    state={
        lectors:[],
        subjects:[],
        lessonTypes:[],
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

    render(){
        const {lectors, subjects, lessonTypes,loading} = this.state;

        const {lectorId} = this.props.match.params;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<CreateLectorSubjectForm lectors={lectors} subjects={subjects} lessonTypes={lessonTypes} initLectorId={lectorId}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateLectorSubjectPage);