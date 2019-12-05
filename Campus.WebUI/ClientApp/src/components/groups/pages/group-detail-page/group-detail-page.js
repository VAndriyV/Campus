import React, {Component} from 'react';
import GroupDetail from '../../components/group-detail';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class GroupDetailPage extends Component{
    state = {
        group:null,
        loading:true
    };

    componentDidMount(){
        this.fetchGroup();
    }

    fetchGroup(){
        const {id} = this.props.match.params;

        this.props.campusService
            .getGroup(id)
            .then((group)=>{
                this.setState({
                    group:group,
                    loading:false
                });
            });
    }

    render(){
        const {group, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<GroupDetail group={group}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(GroupDetailPage);