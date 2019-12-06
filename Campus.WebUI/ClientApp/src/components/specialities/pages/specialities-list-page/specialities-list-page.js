import React, {Component} from 'react';
import SpecialitiesList from '../../components/specialities-list';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class SpecialitiesListPage extends Component{
    state = {
        specialities:[],
        loading:true
    }

    componentDidMount(){
        this.fetchSpecialities();
    }

    fetchSpecialities(){
        this.props.campusService
            .getAllSpecialities()
            .then((res)=>{               
                this.setState({
                    specialities:res.specialities,
                    loading:false
                });
            });
    }

    render(){
        const {specialities, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<SpecialitiesList specialities={specialities}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(SpecialitiesListPage);