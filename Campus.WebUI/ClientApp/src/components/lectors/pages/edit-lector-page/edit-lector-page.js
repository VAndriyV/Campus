import React, {Component} from 'react';
import EditLectorForm from '../../components/edit-lector-form';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class EditLectorPage extends Component{
    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }

    state = {
        lector:null,
        academicRanks:[],
        academicDegrees:[],
        loading:true
    };

    componentDidMount(){
        this.fetchLector();
    }

    fetchLector(){
        const {id} = this.props.match.params;
        const {campusService} = this.props;

        Promise.all([
            campusService.getLector(id), 
            campusService.getAcademicRanks(),                       
            campusService.getAcademicDegrees()
        ])
        .then(([lector,academicRanks,academicDegrees])=>{
            this.setState({
                lector:lector,
                academicRanks:academicRanks.items,
                academicDegrees:academicDegrees.items,
                loading:false
            });
        });
    }

    onSubmit(lector){
        this.props.campusService.updateLector(lector);
    }

    render(){
        const {lector, academicRanks,academicDegrees, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<EditLectorForm academicRanks={academicRanks} academicDegrees ={academicDegrees} 
                lector={lector} onSubmit={this.onSubmit}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditLectorPage);