import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import LoginForm from '../../components/login-form';
import {Link} from 'react-router-dom';

export default class LoginPage extends Component {
    state = {
        hasError: false,
        errorObj: null
    }

    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(credentials) {
        this.props.userService.login(credentials)
            .catch(err => {
                this.setState({
                    hasError: true,
                    errorObj: err
                });
            });
    }

    render() {
        const { hasError, errorObj } = this.state;
        if (hasError && !(errorObj.status === 400 || errorObj.status === 401 || errorObj.status === 404)) {
            throw errorObj;
        }
        return (<Row>
            <Col xs={12}>
                <LoginForm hasError={hasError} errorObj={errorObj} onSubmit={this.onSubmit} />
                <div>
                    <Link to={'/resetpassword'}>Reset password</Link>
                </div>
            </Col>
        </Row>);
    }
}