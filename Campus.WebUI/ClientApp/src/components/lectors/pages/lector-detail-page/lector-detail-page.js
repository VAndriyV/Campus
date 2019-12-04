import React, {Component} from 'react';
import LectorDetail from '../../components/lector-detail';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';

export default class LectorDetailPage extends Component{
    state = {
        lector:null,
        loading:true
    };

    componentDidMount(){
        this.fetchLector();
    }

    fetchLector(){
        const {id} = this.props.match.params.id;

        this.props.campusService
            .getLector(id)
            .then((lector)=>{
                this.setState({
                    lector:lector,
                    loading:false
                });
            });
    }

    render(){
        const {lector, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<LectorDetail lector={lector}/>}
            </Col>
        </Row>)
    }
}