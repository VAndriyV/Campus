import React, {Component} from 'react';
import CreateLectorForm from '../../components/create-lector-form';
import Spinner from '../../../spinner';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class CreateLectorPage extends Component{
    state = {       
        academicRanks:[],
        academicDegrees:[],
        loading:true
    };

    componentDidMount(){
        this.fetchData();
    }

    fetchData(){        
        const {campusService} = this.props;

        Promise.all([            
            campusService.getAcademicRanks(),
            campusService.getAcademicDegrees()
        ])
        .then(([academicRanks,academicDegrees])=>{
            this.setState({               
                academicRanks:academicRanks.items,
                academicDegrees:academicDegrees.items,
                loading:false
            });
        });
    }

    render(){
        const {academicDegrees, academicRanks, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<CreateLectorForm academicRanks={academicRanks} academicDegrees ={academicDegrees}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(CreateLectorPage);