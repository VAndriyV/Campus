import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { FaRegTrashAlt } from 'react-icons/fa';
import { FaPencilAlt } from 'react-icons/fa';

export default class GroupsList extends Component {

    mapGroups(groups) {
        groups.map((item, idx) =>
            this.mapGroup(item, idx));
    };

    mapGroup(group, idx) {
        return (<tr key={group.id} >
            <td>{idx + 1}</td>
            <td>{group.id}</td>
            <td>{group.name}</td>
            <td>{group.specialityCode}</td>
            <td>{group.educationDegreeName}</td>
            <td>{group.year}</td>
            <td>{group.studentsCount}</td>
            <td><FaPencilAlt /><FaRegTrashAlt /></td>
        </tr>);
    }

    render() {
        const { groups } = this.props;

        return (<Table hover responsive>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Speciality code</th>
                    <th>Education degree</th>
                    <th>Year</th>
                    <th>Students count</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {this.mapGroups(groups)}
            </tbody>
        </Table>)
    }
};