import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { FaRegTrashAlt } from 'react-icons/fa';
import { FaPencilAlt } from 'react-icons/fa';

export default class SpecialitiesList extends Component {

    mapSpecialities(specialities) {
        specialities.map((item, idx) =>
            this.mapSpeciality(item, idx));
    };

    mapSpeciality(speciality, idx) {
        return (<tr key={speciality.id} >
            <td>{idx + 1}</td>
            <td>{speciality.id}</td>
            <td>{speciality.name}</td>
            <td>{speciality.code}</td>
            <td><FaPencilAlt /><FaRegTrashAlt /></td>
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