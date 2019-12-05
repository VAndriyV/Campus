import React, {Component} from 'react';
import LectorsList from '../../components/lectors-list';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class LectorsListPage extends Component{
    state = {
        lectors:[],
        loading:true
    }

    componentDidMount(){
        this.fetchLectors();
    }

    fetchLectors(){
        this.props.campusService
            .getAllLectors()
            .then((res)=>{               
                this.setState({
                    lectors:res.lectors,
                    loading:false
                });
            });
    }

    render(){
        const {lectors, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<LectorsList lectors={lectors}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(LectorsListPage);