import React, {Component} from 'react';
import EditLectorForm from '../../components/edit-lector-form';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';

export default class EditLectorPage extends Component{
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
        const {id} = this.props.match.params.id;
        const {campusService} = this.props;

        Promise.all([
            campusService.getLector(id),
            campusService.getAcademicRanks(),
            campusService.getAcademicDegrees()
        ])
        .then(([lector,academicRanks,academicDegrees])=>{
            this.setState({
                lector:lector,
                academicRanks:academicRanks,
                academicDegrees:academicDegrees,
                loading:false
            });
        });
    }

    render(){
        const {lector, academicRanks,academicDegrees, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<EditLectorForm academicRanks={academicRanks} academicDegrees ={academicDegrees} lector={lector}/>}
            </Col>
        </Row>)
    }
}