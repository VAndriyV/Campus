import React, { Component } from 'react';
import GroupDetail from '../../components/group-detail';
import Spinner from '../../../spinner/';
import { Row, Col, TabContent, TabPane, Nav, NavItem, NavLink } from 'reactstrap';
import classnames from 'classnames';
import GroupsLessonsList from '../../../lessons/components/groups-lessons-list';
import DetailActions from '../../../common/detail-actions';

import withCampusService from '../../../hoc/with-campus-service';

class GroupDetailPage extends Component {
  state = {
    activeTab: '1',   
    lessons: [],
    group: null,
    loading: true
  };

  componentDidMount() {
    this.fetchGroup();
  }

  toggle(tab) {
    const { activeTab } = this.state;
    if (activeTab !== tab) {
      this.setState({ activeTab: tab });
    }
  }

  onDelete() {

  }

  fetchGroup() {
    const { id } = this.props.match.params;
    const { campusService } = this.props;
    Promise.all([
      campusService.getGroup(id),     
      campusService.getGroupsLessons(id)
    ]).then(([group,{ lessons }]) => {
      this.setState({
        group: group,        
        lessons: lessons,
        loading: false
      })
    })
  }

  render() {
    const { group, lessons, loading, activeTab } = this.state;
    console.log(group);

    return (<Row>
      <Col xs={12}>
        {loading ? <Spinner /> :
          <div>
            <Nav tabs>
              <NavItem>
                <NavLink
                  className={classnames({ active: activeTab === '1' })}
                  onClick={() => { this.toggle('1'); }}>
                  General
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  className={classnames({ active: activeTab === '2' })}
                  onClick={() => { this.toggle('2'); }}>
                  Lessons
                </NavLink>
              </NavItem>              
            </Nav>
            <TabContent activeTab={activeTab}>
              <TabPane tabId="1">
                {activeTab == 1 ? 
                  <React.Fragment>
                    <DetailActions toEdit={`/groups/edit/${group.id}`} onDelete={this.onDelete}/>                 
                    <GroupDetail group={group}/>
                  </React.Fragment>
                  : null}
              </TabPane>              
              <TabPane tabId="2">
                {activeTab == 2 ? <GroupsLessonsList lessons={lessons} /> : null}
              </TabPane>
            </TabContent>
          </div>}
      </Col>
    </Row>)
  }
}

export default withCampusService(GroupDetailPage);