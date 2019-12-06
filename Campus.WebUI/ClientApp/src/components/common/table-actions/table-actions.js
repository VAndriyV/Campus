import React, { Component } from "react";
import { Button } from "reactstrap";
import { FaPencilAlt, FaRegTrashAlt } from "react-icons/fa";
import { Link } from 'react-router-dom';

export default class TableActions extends Component {

    render() {
        const { toEdit, onDelete } = this.props;

        return (
            <React.Fragment>
                <Button tag={Link} to={toEdit} size="sm" outline color="warning">
                    <FaPencilAlt />
                </Button>
                <Button onClick={onDelete} size="sm" outline color="danger">
                    <FaRegTrashAlt />
                </Button>
            </React.Fragment>);
    }
}