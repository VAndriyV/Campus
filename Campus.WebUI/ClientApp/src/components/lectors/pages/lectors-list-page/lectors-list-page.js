import React, { Component } from 'react';
import LectorsList from '../../components/lectors-list';
import Spinner from '../../../spinner/';
import { Row, Col } from 'reactstrap';
import CreateNewLink from '../../../common/create-new-link';
import withCampusService from '../../../hoc/with-campus-service';

class LectorsListPage extends Component {
    constructor(props){
        super(props);

        this.onDelete = this.onDelete.bind(this);
    }

    state = {
        lectors: [],
        loading: true
    }

    componentDidMount() {
        this.fetchLectors();
    }

    fetchLectors() {
        this.props.campusService
            .getAllLectors()
            .then((res) => {
                this.setState({
                    lectors: res.lectors,
                    loading: false
                });
            });
    }

    onDelete(id){
        this.props.campusService.deleteLector(id);
    }

    render() {
        const { lectors, loading } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <React.Fragment>
                        <CreateNewLink to={'/lectors/new'}/>
                        <LectorsList lectors={lectors} onDelete={this.onDelete} />
                    </React.Fragment>
                }
            </Col>
        </Row>)
    }
}

export default withCampusService(LectorsListPage);