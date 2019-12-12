import React, {Component} from 'react';
import CreateSubjectForm from '../../components/create-subject-form';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class CreateSubjectPage extends Component{   

    onSubmit(subject){
        this.props.campusService.createSubject(subject);
    }

    render(){    

        return (<Row>
            <Col xs={12}>
                <CreateSubjectForm onSubmit={this.onSubmit}/>
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateSubjectPage);
