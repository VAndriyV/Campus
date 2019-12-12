import React, { Component } from "react";
import { Table } from "reactstrap";
import TableActions from '../../../common/table-actions';
import {Link} from 'react-router-dom';

export default class LectorsList extends Component {
  constructor(props){
    super(props);

    this.onDelete = this.onDelete.bind(this);
  }

  mapLectors(lectors) {
    return lectors.map((item, idx) => this.mapLector(item, idx));
  }

  onDelete(id) {
    this.props.onDelete(id);
  }

  mapLector(lector, idx) {
    return (
      <tr key={lector.id}>
        <td>{idx + 1}</td>
        <td><Link to={`/lectors/${lector.id}`}>{lector.id}</Link></td>
        <td>{lector.firstName}</td>
        <td>{lector.lastName}</td>
        <td>{lector.patronymic}</td>
        <td>{lector.academicRankName}</td>
        <td>{lector.academicDegreeName}</td>
        <td>{lector.email}</td>
        <td>{lector.phoneNumber}</td>
        <td>
          <TableActions toEdit={`/lectors/edit/${lector.id}`} onDelete={()=>this.onDelete(lector.id)} />
        </td>
      </tr>
    );
  }

  render() {
    const { lectors } = this.props;

    return (
      <Table hover responsive>
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
        <tbody>{this.mapLectors(lectors)}</tbody>
      </Table>
    );
  }
}
