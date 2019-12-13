import React, { Component } from 'react';
import SpecialitiesList from '../../components/specialities-list';
import Spinner from '../../../spinner/';
import { Row, Col } from 'reactstrap';
import CreateNewLink from '../../../common/create-new-link';
import withCampusService from '../../../hoc/with-campus-service';
import Modal from '../../../common/modal';

class SpecialitiesListPage extends Component {
    constructor(props) {
        super(props);

        this.onDelete = this.onDelete.bind(this);
        this.toggle = this.toggle.bind(this);
    }

    state = {
        specialities: [],
        hasError: false,
        error: '',
        loading: true
    }

    componentDidMount() {
        this.fetchSpecialities();
    }

    fetchSpecialities() {
        this.props.campusService
            .getAllSpecialities()
            .then((res) => {
                this.setState({
                    specialities: res.specialities,
                    loading: false
                });
            });
    }

    onDelete(id) {
        this.props.campusService.deleteSpeciality(id)
            .then(() => this.removeSpecialityFromList(id))
            .catch(err => this.showModal(err));
    }

    removeSpecialityFromList(id) {
        this.setState({
            specialities: this.state.specialities.filter(function (speciality) {
                return speciality.id !== id
            })
        });
    }

    showModal(err) {
        this.setState({
            hasError: true,
            error: err.error
        })
    }

    toggle() {
        this.setState({
            hasError: !this.state.hasError
        });
    }

    render() {
        const { specialities, loading, hasError, error } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <React.Fragment>
                        <CreateNewLink to={'/specialities/new'} />
                        <SpecialitiesList specialities={specialities} onDelete={this.onDelete} />
                        <Modal header='An error has occured while deleting speciality' body={error}
                            modal={hasError} toggle={this.toggle} />
                    </React.Fragment>}
            </Col>
        </Row>)
    }
}

export default withCampusService(SpecialitiesListPage);