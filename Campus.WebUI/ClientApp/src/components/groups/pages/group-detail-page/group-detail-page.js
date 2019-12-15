import React, { Component } from 'react';
import GroupDetail from '../../components/group-detail';
import Spinner from '../../../spinner/';
import { Row, Col, TabContent, TabPane, Nav, NavItem, NavLink } from 'reactstrap';
import classnames from 'classnames';
import GroupsLessonsList from '../../../lessons/components/groups-lessons-list';
import DetailActions from '../../../common/detail-actions';
import withCampusService from '../../../hoc/with-campus-service';
import Modal from '../../../common/modal';
import RangeAttendance from '../../../attendances/components/range-attendance';

class GroupDetailPage extends Component {
  constructor(props) {
    super(props);

    this.onDelete = this.onDelete.bind(this);
    this.onLessonDelete = this.onLessonDelete.bind(this);
    this.toggle = this.toggle.bind(this);
  }

  state = {
    activeTab: '1',
    lessons: [],
    group: null,
    hasError: false,
    error: '',
    header: '',   
    attendanceData:[],    
    loading: true
  };

  componentDidMount() {
    this.fetchGroup();
  }

  toggleTab(tab) {
    const { activeTab } = this.state;
    if (activeTab !== tab) {
      this.setState({ activeTab: tab });
    }
  }

  onDelete() {
    const id = this.state.group.id;
    this.props.campusService.deleteGroup(id)
      .then(() => this.props.history.push('/groups'))
      .catch(err => this.showGroupDeleteErrorModal(err));
  }

  onLessonDelete(id) {
    this.props.campusService.deleteLesson(id)
      .then(() => this.removeLessonFromList(id))
      .catch(err => this.showLessonDeleteErrorModal(err));
  }

  fetchGroup() {
    const { id } = this.props.match.params;
    const { campusService } = this.props;
    Promise.all([
      campusService.getGroup(id),
      campusService.getGroupsLessons(id)
    ]).then(([group, { lessons }]) => {
      this.setState({
        group: group,
        lessons: lessons,
        loading: false
      })
    })
  }

  showLessonDeleteErrorModal(err) {
    const header = 'An error has occured while deleting lesson';
    this.showModal(err, header);
  }

  showGroupDeleteErrorModal(err) {
    const header = 'An error has occured while deleting group';
    this.showModal(err, header);
  }

  showModal(err, header) {
    this.setState({
      hasError: true,
      error: err.error,
      header: header
    })
  }

  removeLessonFromList(id){
    this.setState({lessons: this.state.lessons.filter(function(lesson) { 
        return lesson.id !==id
    })});
  }

  toggle() {
    this.setState({
      hasError: !this.state.hasError
    });
  } 

  loadAttendanceData = (startDate,endDate)=>{ 
    const {group} = this.state;

    this.props.campusService.getGroupsAttendances(group.id,startDate, endDate)
    .then(({data})=>{
      this.setState({
        attendanceData:data    
      })
    })
    .catch(err=>console.log(err));
  }

  render() {
    const { group, lessons, loading, activeTab, error, hasError, header, attendanceData} = this.state;
    return (<Row>
      <Col xs={12}>
        {loading ? <Spinner /> :
          <div>
            <Nav tabs>
              <NavItem>
                <NavLink
                  className={classnames({ active: activeTab === '1' })}
                  onClick={() => { this.toggleTab('1'); }}>
                  General
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  className={classnames({ active: activeTab === '2' })}
                  onClick={() => { this.toggleTab('2'); }}>
                  Lessons
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  className={classnames({ active: activeTab === '3' })}
                  onClick={() => { this.toggleTab('3'); }}>
                  Attendance
                </NavLink>
              </NavItem>
            </Nav>
            <TabContent activeTab={activeTab}>
              <TabPane tabId="1">
                {activeTab == 1 ?
                  <React.Fragment>
                    <DetailActions toEdit={`/groups/edit/${group.id}`} onDelete={this.onDelete} />
                    <GroupDetail group={group} />
                  </React.Fragment>
                  : null}
              </TabPane>
              <TabPane tabId="2">
                {activeTab == 2 ? <GroupsLessonsList lessons={lessons} onDelete={this.onLessonDelete} /> : null}
              </TabPane> 
              <TabPane tabId="3">
                {activeTab == 3 ? <RangeAttendance loadData={this.loadAttendanceData} data={attendanceData}/> 
                : null}
              </TabPane>
            </TabContent>
          </div>}
        <Modal header={header} body={error}
          modal={hasError} toggle={this.toggle} />
      </Col>
    </Row>)
  }
}

export default withCampusService(GroupDetailPage);