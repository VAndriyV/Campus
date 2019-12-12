import React, { Component } from 'react';
import GroupsList from '../../components/groups-list';
import Spinner from '../../../spinner/';
import { Row, Col } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import CreateNewLink from '../../../common/create-new-link';

class GroupsListPage extends Component {
    constructor(props){
        super(props);

        this.onDelete = this.onDelete.bind(this);
    }

    state = {
        groups: [],
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
        this.props.campusService.deleteGroup(id);
    }

    render() {
        const { groups, loading } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <React.Fragment>
                        <CreateNewLink to={'/groups/new'} />
                        <GroupsList groups={groups} onDelete={this.onDelete}/>
                    </React.Fragment>
                }
            </Col>
        </Row>)
    }
}

export default withCampusService(GroupsListPage);