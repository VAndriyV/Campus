import React from 'react';
import { CampusServiceConsumer } from '../campus-service-context';

const withCampusService = (Wrapped) => {

    return (props) => {
        return (
            <CampusServiceConsumer>
                {
                    (swapiService) => {                       

                        return (
                            <Wrapped {...props} service={swapiService} />
                        );
                    }
                }
            </CampusServiceConsumer>
        );
    }
};

export default withCampusService;
