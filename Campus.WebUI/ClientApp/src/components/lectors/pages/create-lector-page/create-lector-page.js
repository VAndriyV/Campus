import React, { Component } from 'react';
import CreateLectorForm from '../../components/create-lector-form';
import Spinner from '../../../spinner';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import { Link } from 'react-router-dom';

class CreateLectorPage extends Component {
    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    state = {
        academicRanks: [],
        academicDegrees: [],
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        createdEntityId: 0,
        loading: true
    };

    componentDidMount() {
        this.fetchData();
    }

    fetchData() {
        const { campusService } = this.props;

        Promise.all([
            campusService.getAcademicRanks(),
            campusService.getAcademicDegrees()
        ])
            .then(([academicRanks, academicDegrees]) => {
                this.setState({
                    academicRanks: academicRanks.items,
                    academicDegrees: academicDegrees.items,
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

    onSubmit(lector) {
        this.setState({
            operationSuccessful: false,
            createdEntityId: 0,
            hasError: false,
            errorObj: null
        });

        this.props.campusService.createLector(lector)
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

    render() {
        const { academicDegrees, academicRanks, loading, operationSuccessful,
            hasError, errorObj, createdEntityId } = this.state;
        if (hasError && !(errorObj.status === 400 || errorObj.status === 409)) {
            throw errorObj;
        }
        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> : <CreateLectorForm academicRanks={academicRanks} academicDegrees={academicDegrees}
                    onSubmit={this.onSubmit} hasError={hasError} errorObj={errorObj} />}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Lector is successfully added.</h5>
                        <p>Go to {<Link to={`/lectors/${createdEntityId}`} className='alert-link'>
                            lector detail page
                            </Link>} or to {<Link to={`/lectors`} className='alert-link'>
                                lectors list
                            </Link>}
                        </p>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateLectorPage);