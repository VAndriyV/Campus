import React from 'react';
import {Route, Redirect} from 'react-router-dom';

export default function AuthenticatedRoute({ component: C, user, requiredRoles, ...rest }) {
    let isAllowed = false;
    if(user){
       for(let role of user.roles){      
         if(requiredRoles.some(x=>x===role))
         {
           isAllowed = true;
           break;
         }
       }
    }   

    return (
      <Route
        {...rest}
        render={props =>
            isAllowed
            ? <C {...props}/>
            : <Redirect
                to={`/login`}
              />}
      />
    );
  }