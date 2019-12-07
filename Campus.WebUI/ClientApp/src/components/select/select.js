import React, { Component } from "react";
import { Label, Input } from "reactstrap";

export default class Select extends Component {
  renderOptions(options) {
    return options.map(x => <option key={x.id} value={x.id}>{x.name || this.generateTextValue(x)}</option>);
  }

  generateTextValue(obj){
    const { textProperties } = this.props;

    let text = '';

    textProperties.forEach(x=>{
      text +=(obj[x] + " ");
    });

    return text;
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
