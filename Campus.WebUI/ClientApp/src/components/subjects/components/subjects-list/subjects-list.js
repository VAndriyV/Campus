import React, { Component } from 'react';
import { Table, Button } from "reactstrap";
import { FaPencilAlt, FaRegTrashAlt } from "react-icons/fa";
import {Link} from 'react-router-dom';

export default class SubjectsList extends Component {
    mapSubjects(subjects) {
        return subjects.map((item, idx) =>
            this.mapSubject(item, idx));
    };

    onDelete(id){

    }

    mapSubject(subject,idx) {
        return (<tr key={subject.id} >
            <td>{idx + 1}</td>
            <td>{subject.id}</td>
            <td>{subject.name}</td>
            <td>
                <Button tag={Link} to={`/subjects/edit/${subject.id}`} size="sm" outline color="warning">
                    <FaPencilAlt />
                </Button>
                <Button onClick={this.onDelete(subject.id)} size="sm" outline color="danger">
                    <FaRegTrashAlt />
                </Button>
            </td>
        </tr>);
    }

    render() {
        const { subjects } = this.props;

        return (<Table hover responsive>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {this.mapSubjects(subjects)}
            </tbody>
        </Table>)
    }
};