import React, { Component } from "react";

export default class LectorDetail extends Component {
  render() {
    const { lector } = this.props;

    return <p>{JSON.stringify(lector)}</p>;
  }
}
