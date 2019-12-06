import React, { Component } from "react";

export default class LectorDetail extends Component {
  render() {
    const { lector } = this.props;

    return (<div>
      <h6>First name</h6>
      <p>{lector.firstName}</p>
      <h6>Last name</h6>
      <p>{lector.lastName}</p>
      <h6>Patronymic</h6>
      <p>{lector.patronymic}</p>
      <h6>Academic rank</h6>
      <p>{lector.academicRankName}</p>
      <h6>Academic degree</h6>
      <p>{lector.academicDegreeName}</p>
      <h6>Email</h6>
      <p>{lector.email}</p>
      <h6>Phone number</h6>
      <p>{lector.phoneNumber}</p>
    </div>)
  }
}
