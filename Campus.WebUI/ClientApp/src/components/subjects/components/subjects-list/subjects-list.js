import React, { Component } from 'react';
import { Table } from 'reactstrap';
import { FaRegTrashAlt } from 'react-icons/fa';
import { FaPencilAlt } from 'react-icons/fa';

export default class SubjectsList extends Component {

    mapSubjects(subjects) {
        subjects.map((item, idx) =>
            this.mapSubject(item, idx));
    };

    mapSubject(subject,idx) {
        return (<tr key={subject.id} >
            <td>{idx + 1}</td>
            <td>{subject.id}</td>
            <td>{subject.name}</td>
            <td><FaPencilAlt /><FaRegTrashAlt/></td>
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