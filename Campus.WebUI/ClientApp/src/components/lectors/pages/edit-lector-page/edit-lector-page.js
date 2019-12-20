import React, { Component } from 'react';
import EditLectorForm from '../../components/edit-lector-form';
import Spinner from '../../../spinner/';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import { Link } from 'react-router-dom';

class EditLectorPage extends Component {
    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    state = {
        lector: null,
        academicRanks: [],
        academicDegrees: [],
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        loading: true
    };

    componentDidMount() {
        this.fetchLector();
    }

    fetchLector() {
        const { id } = this.props.match.params;
        const { campusService } = this.props;

        Promise.all([
            campusService.getLector(id),
            campusService.getAcademicRanks(),
            campusService.getAcademicDegrees()
        ])
            .then(([lector, academicRanks, academicDegrees]) => {
                this.setState({
                    lector: lector,
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
            hasError: false,
            errorObj: null
        });

        this.props.campusService.updateLector(lector)
            .then(() => {
                this.setState({
                    operationSuccessful: true
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
        const { lector, academicRanks, academicDegrees, loading, operationSuccessful, hasError, errorObj } = this.state;
        if (hasError && !(errorObj.status === 400 || errorObj.status === 409)) {
            throw errorObj;
        }
        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> : <EditLectorForm academicRanks={academicRanks} academicDegrees={academicDegrees}
                    lector={lector} onSubmit={this.onSubmit} hasError={hasError} errorObj={errorObj} />}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Group is successfully updated.</h5>
                        <p>Go to {<Link to={`/lectors/${lector.id}`} className='alert-link'>
                            lector detail page
                            </Link>} or to{<Link to={`/lectors`} className='alert-link'>
                                lectors list
                            </Link>}
                        </p>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditLectorPage);