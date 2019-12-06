import React, {Component} from 'react';
import LectorsList from '../../components/lectors-list';
import Spinner from '../../../spinner/';
import {Row,Col, Button} from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import {FaPlus} from 'react-icons/fa';
import {Link} from 'react-router-dom';

class LectorsListPage extends Component{
    state = {
        lectors:[],
        loading:true
    }

    componentDidMount(){
        this.fetchLectors();
    }

    fetchLectors(){
        this.props.campusService
            .getAllLectors()
            .then((res)=>{               
                this.setState({
                    lectors:res.lectors,
                    loading:false
                });
            });
    }

    render(){
        const {lectors, loading} = this.state;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:
                <React.Fragment>
                <div className='actions'>
                <Button tag={Link} to={`/lectors/new`} size="sm" outline color="success">
                        New <FaPlus/>
                </Button>
                </div>    
                <LectorsList lectors={lectors}/>
                </React.Fragment>
                }
            </Col>
        </Row>)
    }
}

export default withCampusService(LectorsListPage);