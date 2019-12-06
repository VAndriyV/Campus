import React, {Component} from 'react';
import EditSpecialityForm from '../../components/edit-speciality-form';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class EditSpecialityPage extends Component{
    state = {
        speciality:null,        
        loading:true
    };

    componentDidMount(){
        this.fetchSpeciality();
    }

    fetchSpeciality(){
        const {id} = this.props.match.params;
        const {campusService} = this.props;
        campusService.getSpeciality(id)
        .then((res)=>{
            this.setState({
                speciality:res,
                loading:false
            });
        }); 
    }

    render(){
        const {speciality, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<EditSpecialityForm speciality={speciality}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditSpecialityPage);