import React, { Component } from 'react';
import { Table, Button } from "reactstrap";
import { FaPencilAlt, FaRegTrashAlt } from "react-icons/fa";
import {Link} from 'react-router-dom';

export default class LectorsLessonsList extends Component {
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
            <td><Link to={`/groups/${lesson.groupId}`}>{lesson.groupName}</Link></td>
            <td>{lesson.subjectName}</td>
            <td>{lesson.lessonTypeName}</td>
            <td>
                <Button tag={Link} to={`/lessons/edit/${lesson.id}`} size="sm" outline color="warning">
                    <FaPencilAlt />
                </Button>
                <Button onClick={this.onDelete(lesson.id)} size="sm" outline color="danger">
                    <FaRegTrashAlt />
                </Button>
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
                    <th>Group</th>
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