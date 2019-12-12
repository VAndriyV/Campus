import React, { Component } from 'react';
import { Table } from "reactstrap";
import TableActions from '../../../common/table-actions';

export default class SpecialitiesList extends Component {
    constructor(props){
        super(props);

        this.onDelete = this.onDelete.bind(this);
    }    

    mapSpecialities(specialities) {
        return specialities.map((item, idx) =>
            this.mapSpeciality(item, idx));
    };

    onDelete(id) {
        this.props.onDelete(id);
    }

    mapSpeciality(speciality, idx) {
        return (<tr key={speciality.id} >
            <td>{idx + 1}</td>
            <td>{speciality.id}</td>
            <td>{speciality.name}</td>
            <td>{speciality.code}</td>
            <td>
                <TableActions toEdit={`/specialities/edit/${speciality.id}`} onDelete={()=>this.onDelete(speciality.id)} />
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