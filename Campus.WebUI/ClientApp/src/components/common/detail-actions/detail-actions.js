import React, { Component } from 'react';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import { FaPencilAlt, FaRegTrashAlt } from "react-icons/fa";

export default class DetailActions extends Component {

    render() {
        const { onDelete, toEdit } = this.props;

        return (<div className='actions'>
            <Button tag={Link} to={toEdit} size="sm" outline color="warning">
                Edit <FaPencilAlt />
            </Button>
            <Button onClick={onDelete()} size="sm" outline color="danger">
                Delete <FaRegTrashAlt />
            </Button>
        </div>);
    }
}
