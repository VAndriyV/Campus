import React, {Component} from 'react';
import CreateLectorForm from '../../components/create-lector-form';
import Spinner from '../../../spinner';
import {Row,Col} from 'reactstrap';

export default class CreateLectorPage extends Component{
    state = {       
        academicRanks:[],
        academicDegrees:[],
        loading:true
    };

    componentDidMount(){
        this.fetchLector();
    }

    fetchLector(){        
        const {campusService} = this.props;

        Promise.all([            
            campusService.getAcademicRanks(),
            campusService.getAcademicDegrees()
        ])
        .then(([academicRanks,academicDegrees])=>{
            this.setState({               
                academicRanks:academicRanks,
                academicDegrees:academicDegrees,
                loading:false
            });
        });
    }

    render(){
        const {academicDegrees, academicRanks, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<CreateLectorForm academicRanks={academicRanks} academicDegrees ={academicDegrees} lector={lector}/>}
            </Col>
        </Row>)
    }
}