import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { FaRegTrashAlt } from 'react-icons/fa';
import { FaPencilAlt } from 'react-icons/fa';

export default class LectorsList extends Component {

    mapLectors(lectors) {
       return lectors.map((item, idx) =>
            this.mapLector(item, idx));
    };

    mapLector(lector, idx) {
        return (<tr key={lector.id} >
            <td>{idx + 1}</td>
            <td>{lector.id}</td>
            <td>{lector.firstName}</td>
            <td>{lector.lastName}</td>
            <td>{lector.patronymic}</td>
            <td>{lector.academicRankName}</td>
            <td>{lector.academicDegreeName}</td>
            <td>{lector.email}</td>
            <td>{lector.phoneNumber}</td>
            <td><FaPencilAlt /><FaRegTrashAlt /></td>
        </tr>);
    }

    render() {
        const { lectors } = this.props;

        return (<Table hover responsive>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Id</th>
                    <th>First name</th>
                    <th>Last name</th>
                    <th>Patronymic</th>
                    <th>Academic rank</th>
                    <th>Academic degree</th>
                    <th>Email</th>
                    <th>Phone number</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {this.mapLectors(lectors)}
            </tbody>
        </Table>)
    }
};