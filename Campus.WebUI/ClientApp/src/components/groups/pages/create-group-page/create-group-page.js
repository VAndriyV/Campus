import React, { Component } from 'react';
import CreateGroupForm from '../../components/create-group-form';
import Spinner from '../../../spinner';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import { Link } from 'react-router-dom';

class CreateGroupPage extends Component {
    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    state = {
        specialities: [],
        educationalDegrees: [],
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        createdEntityId: 0,
        loading: true
    };

    componentDidMount() {
        this.fetchData();
    }

    onSubmit(group) {
        this.setState({
            operationSuccessful: false,
            createdEntityId: 0,
            hasError: false,
            errorObj: null
        });

        this.props.campusService.createGroup(group)
            .then(({ id }) => {
                this.setState({
                    operationSuccessful: true,
                    createdEntityId: id
                })
            })
            .catch(err => {
                this.setState({
                    hasError: true,
                    errorObj: err
                });
            });
    }

    fetchData() {
        const { campusService } = this.props;

        Promise.all([
            campusService.getAllSpecialities(),
            campusService.getEducationalDegrees()
        ])
            .then(([specialities, educationalDegrees]) => {
                this.setState({
                    specialities: specialities.specialities,
                    educationalDegrees: educationalDegrees.items,
                    loading: false
                });
            })
            .catch(err => {
                this.setState({
                    hasError: true,
                    errorObj: err
                });
            });
    }

    render() {
        const { educationalDegrees, specialities, loading, hasError, errorObj,
            operationSuccessful, createdEntityId } = this.state;
        if (hasError && !(errorObj.status === 400 || errorObj.status === 409)) {
            throw errorObj;
        }

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> : <CreateGroupForm educationalDegrees={educationalDegrees}
                    specialities={specialities} onSubmit={this.onSubmit} hasError={hasError} errorObj={errorObj} />}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Group is successfully added.</h5>
                        <p>Go to {<Link to={`/groups/${createdEntityId}`} className='alert-link'>
                            group detail page
                            </Link>} or to{<Link to={`/groups`} className='alert-link'>
                                groups list
                            </Link>}
                        </p>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateGroupPage);