import React, {Component} from 'react';
import CreateSpecialityForm from '../../components/create-speciality-form';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class CreateSpecialityPage extends Component{   
    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(speciality){
        this.props.campusService.createSpeciality(speciality);
    }

    render(){       

        return (<Row>
            <Col xs={12}>
                <CreateSpecialityForm onSubmit={this.onSubmit}/>
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateSpecialityPage);
