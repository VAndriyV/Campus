import React, { Component } from 'react';
import LectorsList from '../../components/lectors-list';
import Spinner from '../../../spinner/';
import { Row, Col } from 'reactstrap';
import CreateNewLink from '../../../common/create-new-link';
import withCampusService from '../../../hoc/with-campus-service';
import Modal from '../../../common/modal';

class LectorsListPage extends Component {
    constructor(props){
        super(props);

        this.onDelete = this.onDelete.bind(this);
        this.toggle = this.toggle.bind(this);
    }

    state = {
        lectors: [],
        hasError:false,        
        error:'',
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
        this.props.campusService.deleteLector(id)
        .then(()=>this.removeLectorFromList(id))
        .catch(err=>this.showModal(err));
    }

    removeLectorFromList(id){
        this.setState({lectors: this.state.lectors.filter(function(lector) { 
            return lector.id !==id
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
        const { lectors, loading, hasError, error } = this.state;

        return (<Row>
            <Col xs={12}>
                {loading ? <Spinner /> :
                    <React.Fragment>
                        <CreateNewLink to={'/lectors/new'}/>
                        <LectorsList lectors={lectors} onDelete={this.onDelete} />
                        <Modal header='An error has occured while deleting lector' body = {error} 
                            modal = {hasError} toggle={this.toggle}/>
                    </React.Fragment>
                }
            </Col>
        </Row>)
    }
}

export default withCampusService(LectorsListPage);