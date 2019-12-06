import React, { Component } from 'react';
import {FaPlus} from 'react-icons/fa';
import {Link} from 'react-router-dom';
import {Button} from 'reactstrap';

export default class CreateNewLink extends Component {
    render() {
        const { to } = this.props;

        return (<div className='actions'>
            <Button tag={Link} to={to} size="sm" outline color="success">
                New <FaPlus />
            </Button>
        </div>);
    }
}