import React, { Component } from 'react';
import LectorDetail from '../../components/lector-detail';
import Spinner from '../../../spinner/';
import { Row, Col, TabContent, TabPane, Nav, NavItem, NavLink, Button } from 'reactstrap';
import classnames from 'classnames';
import LectorsSubjectsList from '../../../lector-subjects/lectors-subjects-list';
import LectorsLessonsList from '../../../lessons/lectors-lessons-list';
import { Link } from 'react-router-dom';
import { FaPencilAlt, FaRegTrashAlt } from "react-icons/fa";

import withCampusService from '../../../hoc/with-campus-service';

class LectorDetailPage extends Component {
  state = {
    activeTab: '1',
    lectorsSubjects: [],
    lessons: [],
    lector: null,
    loading: true
  };

  componentDidMount() {
    this.fetchLector();
  }

  toggle(tab) {
    const { activeTab } = this.state;
    if (activeTab !== tab) {
      this.setState({ activeTab: tab });
    }
  }

  onDelete() {

  }

  fetchLector() {
    const { id } = this.props.match.params;
    const { campusService } = this.props;
    Promise.all([
      campusService.getLector(id),
      campusService.getLectorsSubjects(id),
      campusService.getLectorsLessons(id)
    ]).then(([lector, { lectorsSubjects }, { lessons }]) => {
      this.setState({
        lector: lector,
        lectorsSubjects: lectorsSubjects,
        lessons: lessons,
        loading: false
      })
    })
  }

  render() {
    const { lector, lectorsSubjects, lessons, loading, activeTab } = this.state;

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
                  Subjects
                    </NavLink>
              </NavItem>
              <NavItem>
                <NavLink
                  className={classnames({ active: activeTab === '3' })}
                  onClick={() => { this.toggle('3'); }}>
                  Lessons
                    </NavLink>
              </NavItem>
            </Nav>
            <TabContent activeTab={activeTab}>
              <TabPane tabId="1">
                {activeTab == 1 ?
                  <React.Fragment>
                    <div className = 'actions'>
                      <Button tag={Link} to={`/lectors/edit/${lector.id}`} size="sm" outline color="warning">
                        Edit <FaPencilAlt />
                      </Button>
                      <Button onClick={this.onDelete()} size="sm" outline color="danger">
                        Delete <FaRegTrashAlt />
                      </Button>
                    </div>
                    <LectorDetail lector={lector}/>
                  </React.Fragment>
                  : null}
              </TabPane>
              <TabPane tabId="2">
                {activeTab == 2 ? <LectorsSubjectsList lectorsSubjects={lectorsSubjects} /> : null}
              </TabPane>
              <TabPane tabId="3">
                {activeTab == 3 ? <LectorsLessonsList lessons={lessons} /> : null}
              </TabPane>
            </TabContent>
          </div>}
      </Col>
    </Row>)
  }
}

export default withCampusService(LectorDetailPage);