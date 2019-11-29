import React, { Component } from 'react';
import { Label, Input } from 'reactstrap';

export default class Select extends Component {

    renderOptions(options) {
        return options.map(x =>
            <option value={x.id}>{x.name}</option>);
    }

    render() {
        const { name, options } = this.props.options;

        return (<Label for="exampleSelect">Select</Label>
            <Input type="select" name={name} id="select-{name}" >
            { this.renderOptions(options) }
            </Input >
          );
    };
}

