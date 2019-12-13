import React, {Component} from 'react';
import EditGroupForm from '../../components/edit-group-form';
import Spinner from '../../../spinner';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class EditGroupPage extends Component{
    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }    

    state={
        group:null,
        specialities:[],
        educationalDegrees:[],
        loading:true
    };

    componentDidMount(){
        this.fetchGroup();
    }

    onSubmit(group){
        this.props.campusService.updateGroup(group);
    }

    fetchGroup() {
        const {id} = this.props.match.params;
        const {campusService} = this.props;

        Promise.all([
            campusService.getGroup(id),            
            campusService.getAllSpecialities(),
            campusService.getEducationalDegrees()
        ])
        .then(([group,specialities,educationalDegrees])=>{
            this.setState({
                group,
                specialities:specialities.specialities,               
                educationalDegrees: educationalDegrees.items,
                loading:false
            });
        });
    }

    render(){
        const {group,educationalDegrees, specialities, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<EditGroupForm group = {group} educationalDegrees = {educationalDegrees} 
                specialities={specialities} onSubmit={this.onSubmit}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditGroupPage);