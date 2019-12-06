import React, {Component} from 'react';
import EditSubjectForm from '../../components/edit-subject-form';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class EditSubjectPage extends Component{
    state = {
        subject:null,        
        loading:true
    };

    componentDidMount(){
        this.fetchSubject();
    }

    fetchSubject(){
        const {id} = this.props.match.params;
        const {campusService} = this.props;
        campusService.getSubject(id)
        .then((res)=>{
            this.setState({
                subject:res,
                loading:false
            });
        }); 
    }

    render(){
        const {subject, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<EditSubjectForm subject={subject}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditSubjectPage);