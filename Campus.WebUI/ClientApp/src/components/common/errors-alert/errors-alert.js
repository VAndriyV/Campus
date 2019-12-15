import React, { Component } from 'react';
import { Alert } from 'reactstrap';

export default class ErrorsAlert extends Component {
    state = {
        visible: true        
    }

    hide = () => {
        this.setState({
            visible: false
        });
    };

    mapValidationMessages(errors) {
        return Object.keys(errors).map((item,idx) => <li key={idx}>{`${errors[item]}`}</li>);
    }

    mapErrorMessages(errors){
        console.log(errors);
        return errors.map((item,idx) => <li key={idx}>{`${item}`}</li>);
    }

    displayErrorMessages(error){
        if(error.status===400){
            return this.mapValidationMessages(error.invalidFields);
        }
        else{
            return this.mapErrorMessages(error.error);
        }
    }

    render() {
        const { visible } = this.state;
        const { error } = this.props;

        return (<div className='form-alert'>
            <Alert color="danger" isOpen={visible} toggle={this.hide}>
            <h5 className="alert-heading"> Following errors have been occured:</h5> 
                <ul>
                    {this.displayErrorMessages(error)}
                </ul>
            </Alert>
        </div>);
    }
}