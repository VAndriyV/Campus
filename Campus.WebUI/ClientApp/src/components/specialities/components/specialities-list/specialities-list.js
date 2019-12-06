import React, { Component } from 'react';
import { Table, Button } from "reactstrap";
import { FaPencilAlt, FaRegTrashAlt } from "react-icons/fa";
import {Link} from 'react-router-dom';

export default class SpecialitiesList extends Component {

    mapSpecialities(specialities) {
        return specialities.map((item, idx) =>
            this.mapSpeciality(item, idx));
    };

    onDelete(id){

    }

    mapSpeciality(speciality, idx) {
        return (<tr key={speciality.id} >
            <td>{idx + 1}</td>
            <td>{speciality.id}</td>
            <td>{speciality.name}</td>
            <td>{speciality.code}</td>
            <td>
                <Button tag={Link} to={`/specialities/edit/${speciality.id}`} size="sm" outline color="warning">
                    <FaPencilAlt />
                </Button>
                <Button onClick={this.onDelete(speciality.id)} size="sm" outline color="danger">
                    <FaRegTrashAlt />
                </Button>
            </td>
        </tr>);
    }

    render() {
        const { specialities } = this.props;

        return (<Table hover responsive>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Code</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {this.mapSpecialities(specialities)}
            </tbody>
        </Table>)
    }
};