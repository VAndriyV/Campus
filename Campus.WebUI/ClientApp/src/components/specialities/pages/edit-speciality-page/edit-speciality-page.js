import React, { Component } from 'react';
import EditSpecialityForm from '../../components/edit-speciality-form';
import Spinner from '../../../spinner/';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import { Link } from 'react-router-dom';

class EditSpecialityPage extends Component {
    state = {
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        speciality: null,
        loading: true
    };

    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    componentDidMount() {
        this.fetchSpeciality();
    }

    fetchSpeciality() {
        const { id } = this.props.match.params;
        const { campusService } = this.props;
        campusService.getSpeciality(id)
            .then((res) => {
                this.setState({
                    speciality: res,
                    loading: false
                });
            });
    }

    onSubmit(speciality) {
        this.setState({
            operationSuccessful: false,
            hasError: false,
            errorObj: null
        });

        this.props.campusService.updateSpeciality(speciality)
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
        const { speciality, loading, hasError, errorObj, operationSuccessful } = this.state;
        if (hasError && !(errorObj.status === 400 || errorObj.status === 409)) {
            throw errorObj;
        }
        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> : <EditSpecialityForm speciality={speciality} hasError={hasError} errorObj={errorObj} />}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Speciality is successfully updated.</h5>
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

export default withCampusService(EditSpecialityPage);