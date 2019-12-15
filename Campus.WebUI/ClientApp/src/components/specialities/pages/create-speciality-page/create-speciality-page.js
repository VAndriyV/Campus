import React, { Component } from 'react';
import CreateSpecialityForm from '../../components/create-speciality-form';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import { Link } from 'react-router-dom';

class CreateSpecialityPage extends Component {
    state = {
        hasError: false,
        errorObj: null,
        operationSuccessful: false
    }

    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(speciality) {
        this.setState({
            operationSuccessful: false,
            hasError: false,
            errorObj: null
        });

        this.props.campusService.createSpeciality(speciality)
            .then(() => {
                this.setState({
                    operationSuccessful: true
                })
            })
            .catch(err => {
                if (err.status === 400 || err.status === 409) {
                    this.setState({
                        hasError: true,
                        errorObj: err
                    });
                }
                else {
                    throw err;
                }
            });
    }

    render() {
        const { hasError, errorObj, operationSuccessful } = this.state;

        return (<Row>
            <Col xs={12}>
                <CreateSpecialityForm onSubmit={this.onSubmit} hasError={hasError} errorObj={errorObj} />
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Speciality is successfully added.</h5>
                        <p>Go to {<Link to={`/specialities`} className='alert-link'>
                            specialities list
                            </Link>}
                        </p>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateSpecialityPage);
