import React, { Component } from "react";
import { Label, Input } from "reactstrap";

export default class Select extends Component {

  componentDidMount() {
    this.dispatchChangeEvent();
  }

  componentDidUpdate(prevProps) {   
    
    if (prevProps.options.length !== this.props.options.length) {
      this.dispatchChangeEvent();
      return;
    }

    for (let i = 0; i < prevProps.options.length; i++) {
      if (prevProps.options[i].id != this.props.options[i].id) {
        this.dispatchChangeEvent();
        return
      }
    }
  }

  dispatchChangeEvent() {
    const select = document.getElementById(this.props.name);
    select.dispatchEvent(new Event('change', { bubbles: true }));
  }

  renderOptions(options) {
    return options.map(x => <option key={x.id} value={x.id}>{x.name || this.generateTextValue(x)}</option>);
  }

  generateTextValue(obj) {
    const { textProperties } = this.props;

    let text = '';

    textProperties.forEach(x => {
      text += (obj[x] + " ");
    });

    return text;
  }

  render() {
    const { label, name, options, initValue, onChange } = this.props;

    return (
      <React.Fragment>
        <Label for="name">{label}</Label>
        <Input ref={"select"} type="select" name={name} id={name} onChange={onChange} defaultValue={initValue}>
          {options && this.renderOptions(options)}
        </Input>
      </React.Fragment>
    );
  }
}
