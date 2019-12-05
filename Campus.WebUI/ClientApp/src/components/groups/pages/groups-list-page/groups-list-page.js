import React, {Component} from 'react';
import GroupsList from '../../components/groups-list';
import Spinner from '../../../spinner/';
import {Row,Col} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';

class GroupsListPage extends Component{
    state = {
        groups:[],
        loading:true
    }

    componentDidMount(){
        this.fetchGroups();
    }

    fetchGroups(){
        this.props.campusService
            .getAllGroups()
            .then((res)=>{               
                this.setState({
                    groups:res.groups,
                    loading:false
                });
            });
    }

    render(){
        const {groups, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<GroupsList groups={groups}/>}
            </Col>
        </Row>)
    }
}

export default withCampusService(GroupsListPage);