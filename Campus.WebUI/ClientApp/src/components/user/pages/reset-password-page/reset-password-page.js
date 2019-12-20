import React, { Component } from 'react';
import { Row, Col, Alert } from 'reactstrap';
import ResetPasswordForm from '../../components/reset-password-form';

export default class ResetPasswordPage extends Component{
    state = {
        operationSuccessful:false,
        hasError: false,
        errorObj: null
    }

    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(resetInfo) {
        this.setState({
            operationSuccessful:false,
            hasError:false,
            errorObj:null
        });       

        this.props.userService.resetPassword(resetInfo)
            .then(()=> this.setState({
                operationSuccessful:true
            })
            )
            .catch(err => {
                this.setState({
                    hasError: true,
                    errorObj: err
                });
            });
    }

    render() {
        const { hasError, errorObj, operationSuccessful } = this.state;
        if (hasError && errorObj.status === 500) {
            throw errorObj;
        }
        return (<Row>
            <Col xs={12}>
                <ResetPasswordForm hasError={hasError} errorObj={errorObj} onSubmit={this.onSubmit} />
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading">The password has been sent to your email.</h5>                        
                    </Alert>
                </div> : null}
            </Col>
        </Row>);
    }
}