import React, { Component } from 'react';
import GroupsList from '../../components/groups-list';
import Spinner from '../../../spinner/';
import { Row, Col } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import CreateNewLink from '../../../common/create-new-link';
import Modal from '../../../common/modal';

class GroupsListPage extends Component {
    constructor(props){
        super(props);

        this.onDelete = this.onDelete.bind(this);
        this.toggle = this.toggle.bind(this);
    }

    state = {
        groups: [],
        hasError:false,        
        error:'',
        loading: true
    }

    componentDidMount() {
        this.fetchGroups();
    }

    fetchGroups() {
        this.props.campusService
            .getAllGroups()
            .then((res) => {
                this.setState({
                    groups: res.groups,
                    loading: false
                });
            });
    }

    onDelete(id){       
        this.props.campusService.deleteGroup(id)
        .then(() => this.removeGroupFromList(id))
        .catch(err=>this.showModal(err));
    }

    removeGroupFromList(id){
        this.setState({groups: this.state.groups.filter(function(group) { 
            return group.id !==id
        })});
    }

    showModal(err){
        this.setState({
            hasError:true,
            error:err.error
        })
    }

    toggle(){
        this.setState({
            hasError:!this.state.hasError
        });
    }

    render() {
        const { groups, loading, hasError,error } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <React.Fragment>                        
                        <CreateNewLink to={'/groups/new'} />
                        <GroupsList groups={groups} onDelete={this.onDelete}/>
                        <Modal header='An error has occured while deleting group' body = {error} 
                            modal = {hasError} toggle={this.toggle}/>
                    </React.Fragment>
                }
            </Col>
        </Row>)
    }
}

export default withCampusService(GroupsListPage);