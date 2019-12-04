import React from 'react';
import { CampusServiceConsumer } from '../campus-service-context';

const withCampusService = (Wrapped) => {

    return (props) => {
        return (
            <CampusServiceConsumer>
                {
                    (campusService) => {                       

                        return (
                            <Wrapped {...props} campusService={campusService} />
                        );
                    }
                }
            </CampusServiceConsumer>
        );
    }
};

export default withCampusService;
