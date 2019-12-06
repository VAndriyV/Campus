import React, {Component} from 'react';
import CreateSpecialityForm from '../../components/create-speciality-form';
import {Row,Col} from 'reactstrap';

export default class CreateSpecialityPage extends Component{   

    render(){       

        return (<Row>
            <Col xs={12}>
                <CreateSpecialityForm/>
            </Col>
        </Row>)
    }
}
