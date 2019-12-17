import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';
import LoginForm from '../../components/login-form';

export default class LoginPage extends Component {
    state={
        hasError:false,
        errorObj:null
    }  

    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    onSubmit(credentials) {      
        this.props.userService.login(credentials)          
            .catch(err => {
                if (err.status === 400 || err.status === 401) {
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
        const { hasError, errorObj } = this.state;

        return (<Row>
            <Col xs={12}>
                <LoginForm hasError={hasError} errorObj={errorObj} onSubmit={this.onSubmit}/>
            </Col>
        </Row>);
    }
}