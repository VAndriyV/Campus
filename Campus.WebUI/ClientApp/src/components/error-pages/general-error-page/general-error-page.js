import React, { Component } from 'react';

export default class GeneralErrorPage extends Component {

    render() {
        return (
            <div className="page-wrap d-flex flex-row align-items-center">
                <div className="container">
                    <div className="row justify-content-center">
                        <div className="col-md-12 text-center">
                            <span className="display-1 d-block">An error has been occured</span>
                            <div className="mb-4 lead">It may be server problems, please try to reload page</div>
                            <a href="/" className="btn btn-link">Back to Home</a> 
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}