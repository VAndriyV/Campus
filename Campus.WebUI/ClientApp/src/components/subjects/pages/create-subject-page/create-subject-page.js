import React, {Component} from 'react';
import CreateSubjectForm from '../../components/create-subject-form';
import {Row,Col} from 'reactstrap';

export default class CreateSubjectPage extends Component{   

    render(){       

        return (<Row>
            <Col xs={12}>
                <CreateSubjectForm/>
            </Col>
        </Row>)
    }
}
