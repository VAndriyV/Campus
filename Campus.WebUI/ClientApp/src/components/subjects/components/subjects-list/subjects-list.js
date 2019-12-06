import React, { Component } from 'react';
import { Table } from "reactstrap";
import TableActions from '../../../common/table-actions';

export default class SubjectsList extends Component {
    mapSubjects(subjects) {
        return subjects.map((item, idx) =>
            this.mapSubject(item, idx));
    };

    onDelete(id) {

    }

    mapSubject(subject, idx) {
        return (<tr key={subject.id} >
            <td>{idx + 1}</td>
            <td>{subject.id}</td>
            <td>{subject.name}</td>
            <td>
                <TableActions toEdit={`/subjects/edit/${subject.id}`} onDelete={this.onDelete()} />
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