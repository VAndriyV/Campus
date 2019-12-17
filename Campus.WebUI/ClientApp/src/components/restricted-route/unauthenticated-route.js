import React from 'react';
import { Route, Redirect } from 'react-router-dom';

export default function UnauthenticatedRoute({ component: C, user, ...rest }) {    
    return (
        <Route           
            render={props =>               
                !user
                    ? <C {...props}  {...rest}/>
                    : <Redirect to="/" />}
        />)
};