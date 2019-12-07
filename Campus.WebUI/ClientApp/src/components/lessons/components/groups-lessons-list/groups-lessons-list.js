import React, { Component } from 'react';
import { Table} from "reactstrap";
import TableActions from '../../../common/table-actions';
import {Link} from 'react-router-dom';

export default class GroupsLessonsList extends Component {
    mapLessons(lessons) {
        return lessons.map((item, idx) =>
            this.mapLesson(item, idx));
    };

    onDelete(id){

    }

    mapLesson(lesson,idx) {
        return (<tr key={lesson.id} >
            <td>{idx + 1}</td>
            <td>{lesson.id}</td>
            <td><Link to={`/lectors/${lesson.lectorId}`}>{lesson.lectorName}</Link></td>
            <td>{lesson.subjectName}</td>
            <td>{lesson.lessonTypeName}</td>
            <td>
                <TableActions toEdit={`/lessons/edit/${lesson.id}`} onDelete={this.onDelete()}/>                
            </td>
        </tr>);
    }

    render() {
        const { lessons } = this.props;

        return (<Table hover responsive>
            <thead>
                <tr>
                    <th>#</th>
                    <th>Id</th>
                    <th>Lector</th>
                    <th>Subject</th>
                    <th>Lesson type</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {this.mapLessons(lessons)}
            </tbody>
        </Table>)
    }
};