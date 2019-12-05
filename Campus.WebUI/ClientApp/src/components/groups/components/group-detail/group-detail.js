import React, {Component} from 'react';

export default class GroupDetail extends Component{
    
    render(){
        const {group} = this.props;

        return <p>{JSON.stringify(group)}</p>;
    }
}