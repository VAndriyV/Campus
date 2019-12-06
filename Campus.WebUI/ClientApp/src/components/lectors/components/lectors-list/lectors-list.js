import React, { Component } from "react";
import { Table, Button } from "reactstrap";
import { FaPencilAlt, FaRegTrashAlt } from "react-icons/fa";
import {Link} from 'react-router-dom';

export default class LectorsList extends Component {
  mapLectors(lectors) {
    return lectors.map((item, idx) => this.mapLector(item, idx));
  }

  onDelete(id){

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
          <Button tag={Link} to={`/lectors/edit/${lector.id}`} size="sm" outline color="warning">
            <FaPencilAlt />
          </Button>
          <Button onClick={this.onDelete(lector.id)} size="sm" outline color="danger">
            <FaRegTrashAlt />
          </Button>
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
