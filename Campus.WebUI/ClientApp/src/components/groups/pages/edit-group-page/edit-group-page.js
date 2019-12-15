import React, {Component} from 'react';
import EditGroupForm from '../../components/edit-group-form';
import Spinner from '../../../spinner';
import { Row, Col, Alert } from 'reactstrap';
import withCampusService from '../../../hoc/with-campus-service';
import { Link } from 'react-router-dom';

class EditGroupPage extends Component{
    constructor(props){
        super(props);

        this.onSubmit = this.onSubmit.bind(this);
    }    

    state={
        group:null,
        specialities:[],
        educationalDegrees:[],
        hasError: false,
        errorObj: null,
        operationSuccessful: false,
        loading:true
    };

    componentDidMount(){
        this.fetchGroup();
    }

    onSubmit(group){
        this.setState({
            operationSuccessful: false,           
            hasError: false,
            errorObj: null
        });

        this.props.campusService.updateGroup(group)
            .then(() => {
                this.setState({
                    operationSuccessful: true                  
                })
            })
            .catch(err => {               
                if (err.status === 400 || err.status=== 409) {
                    this.setState({
                        hasError: true,
                        errorObj: err
                    });
                }
                else {
                    throw err;
                }
            });
    }

    fetchGroup() {
        const {id} = this.props.match.params;
        const {campusService} = this.props;

        Promise.all([
            campusService.getGroup(id),            
            campusService.getAllSpecialities(),
            campusService.getEducationalDegrees()
        ])
        .then(([group,specialities,educationalDegrees])=>{
            this.setState({
                group,
                specialities:specialities.specialities,               
                educationalDegrees: educationalDegrees.items,
                loading:false
            });
        });
    }

    render(){
        const {group,educationalDegrees, specialities, loading, hasError, errorObj,
            operationSuccessful,} = this.state ;

        return (<Row>
            <Col xs={12}>
                {loading?<Spinner/>:<EditGroupForm group = {group} educationalDegrees = {educationalDegrees} 
                specialities={specialities} onSubmit={this.onSubmit} hasError={hasError} errorObj={errorObj}/>}
                {operationSuccessful ? <div className='form-alert'>
                    <Alert color="success">
                        <h5 className="alert-heading"> Group is successfully updated.</h5> 
                        <p>Go to {<Link to={`/groups/${group.id}`} className='alert-link'>
                            group detail page
                            </Link>} or to {<Link to={`/groups`} className='alert-link'>
                                groups list
                            </Link>} 
                        </p>
                    </Alert>
                </div> : null}
            </Col>
        </Row>)
    }
}

export default withCampusService(EditGroupPage);