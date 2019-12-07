import React, {Component} from 'react';

export default class GroupDetail extends Component{
    
    render(){
        const {group} = this.props;

        return (<div>
            <h6>Name</h6>
            <p>{group.name}</p>
            <h6>Speciality</h6>
            <p>{`${group.specialityName} (${group.specialityCode})`}</p>
            <h6>Educational degree</h6>
            <p>{group.educationalDegreeName}</p>
            <h6>Year</h6>
            <p>{group.year}</p>
            <h6>Students count</h6>
            <p>{group.studentsCount}</p>
        </div>);
    }
}