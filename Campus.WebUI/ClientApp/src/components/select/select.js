import React, { Component } from "react";
import { Label, Input } from "reactstrap";

export default class Select extends Component {
  renderOptions(options) {
    return options.map(x => <option key={x.id} value={x.id}>{x.name}</option>);
  }

  render() {
    const { label, name, options, initValue } = this.props;

    return (
      <React.Fragment>
        <Label for="name">{label}</Label>
        <Input type="select" name={name} id="name" defaultValue={initValue}>
          {this.renderOptions(options)}
        </Input>
      </React.Fragment>
    );
  }
}
