import React, { Component } from 'react';
import EditSubjectForm from '../../components/edit-subject-form';
import Spinner from '../../../spinner/';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import { Link } from 'react-router-dom';

class EditSubjectPage extends Component {
    state = {
        subject: null,
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        loading: true
    };

    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    componentDidMount() {
        this.fetchSubject();
    }

    fetchSubject() {
        const { id } = this.props.match.params;
        const { campusService } = this.props;
        campusService.getSubject(id)
            .then((res) => {
                this.setState({
                    subject: res,
                    loading: false
                });
            });
    }

    onSubmit(subject) {
        this.setState({
            operationSuccessful: false,
            hasError: false,
            errorObj: null
        });

        this.props.campusService.updateSubject(subject)
            .then(({ id }) => {
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
        const { subject, loading, hasError, errorObj,
            operationSuccessful } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> : <EditSubjectForm subject={subject} onSubmit={this.onSubmit} hasError={hasError} errorObj={errorObj} />}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Subject is successfully updated.</h5>
                        <p>Go to {<Link to={`/subjects`} className='alert-link'>
                            subjects list
                            </Link>}
                        </p>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditSubjectPage);