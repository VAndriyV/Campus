import React, { Component } from 'react';
import { Label, Input } from 'reactstrap';

export default class Select extends Component {

    renderOptions(options) {
        return options.map(x =>
            <option value={x.id}>{x.name}</option>);
    }

    render() {
        const { name, options, initValue } = this.props.options;
        
        return (<Label for="name">Select</Label>
            <Input type="select" name={name} id="name" value={initValue}>
            { this.renderOptions(options) }
            </Input >
          );
    };
}

