import React, {Component} from 'react';
import SpecialitiesList from '../../components/specialities-list';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import CreateNewLink from '../../../common/create-new-link';
import withCampusService from '../../../hoc/with-campus-service';

class SpecialitiesListPage extends Component{
    constructor(props){
        super(props);

        this.onDelete = this.onDelete.bind(this);
    }

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

    onDelete(id){
        this.props.campusService.deleteSpeciality(id);
    }

    render(){
        const {specialities, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:
                <React.Fragment>
                    <CreateNewLink to={'/specialities/new'}/>
                    <SpecialitiesList specialities={specialities} onDelete={this.onDelete}/>
                </React.Fragment>}
            </Col>
        </Row>)
    }
}

export default withCampusService(SpecialitiesListPage);