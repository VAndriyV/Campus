import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { FaRegTrashAlt, FaPen } from 'react-icons/fa';
import {Link} from 'react-router-dom';
import {Button} from 'reactstrap';

export default class GroupsList extends Component {
    mapGroups(groups) {
       return groups.map((item, idx) =>
            this.mapGroup(item, idx));
    };

    onDelete(id){

    }

    mapGroup(group, idx) {
        return (<tr key={group.id} >
            <td>{idx + 1}</td>
            <td><Link to={`/groups/${group.id}`}>{group.id}</Link></td>
            <td>{group.name}</td>
            <td>{group.specialityCode}</td>
            <td>{group.educationalDegreeName}</td>
            <td>{group.year}</td>
            <td>{group.studentsCount}</td>
            <td>
                <Button tag={Link} to={`/groups/edit/${group.id}`} size="sm" outline color="warning">
                    <FaPen />
                </Button>
                <Button onClick={this.onDelete(group.id)} size="sm" outline color="danger">
                    <FaRegTrashAlt />
                </Button>
            </td>
        </tr>);
    }

    render() {        
        const { groups } = this.props;
        console.log(groups);

        return (<Table hover responsive>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Speciality code</th>
                    <th>Educational degree</th>
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