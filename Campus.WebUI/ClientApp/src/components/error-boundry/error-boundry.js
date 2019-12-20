import React, { Component } from 'react';
import GeneralErrorPage from '../error-pages/general-error-page';
import NotFoundErrorPage from '../error-pages/not-found-page';

export default class ErrorBoundry extends Component {

    state = {
        error: null,
        hasError: false
    };

    componentDidCatch(error) {
        this.setState({
            error: error,
            hasError: true
        });
    }

    render() {
        const { hasError, error} = this.state;

        if (hasError) {
            if(error.status===404){
                return <NotFoundErrorPage/>;
            }
            return <GeneralErrorPage />;
        }

        return this.props.children;
    }
}
