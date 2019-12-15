import React, { Component } from 'react';
import { Button } from 'reactstrap';
import LineChart from '../../../common/line-chart';
import DatePicker from 'react-datepicker';

export default class RangeAttendance extends Component {
    state = {
        startDate: new Date(),
        endDate: new Date(),
        buttonHasBeenClicked: false
    }

    handleStartDateChange = (value) => {
        value.setHours(0,0,0,0);
        this.setState({ startDate: value });
    }

    handleEndDateChange = (value) => {
        value.setHours(0,0,0,0);
        this.setState({ endDate: value });
    }

    handleClick = () => {
        const { startDate, endDate, buttonHasBeenClicked } = this.state;
        if (!buttonHasBeenClicked) {
            this.setState({
                buttonHasBeenClicked: true
            });
        }

        if (endDate >= startDate) {
            this.props.loadData(startDate.toISOString(), endDate.toISOString());
        }
        else {
            console.log('date range is invalid');
        }
    }

    render() {
        const { data } = this.props;
        const { startDate, endDate, buttonHasBeenClicked } = this.state;       
        return (<React.Fragment>
            <div className="attendance-filter">
                <div className='date-range-wrapper'>
                    <div className='date-picker'>
                        <span>From</span>
                        <DatePicker
                            selected={startDate}
                            onChange={this.handleStartDateChange}
                            onCha
                            selectsStart
                            startDate={startDate}
                            endDate={endDate}
                            todayButton="Today"
                        /></div>
                    <div className='date-picker'>
                        <span>to</span>
                        <DatePicker
                            selected={endDate}
                            onChange={this.handleEndDateChange}
                            selectsEnd
                            startDate={startDate}
                            endDate={endDate}
                            minDate={startDate}
                            todayButton="Today"
                        /></div>
                </div>
                <Button color="secondary" outline size="sm" onClick={this.handleClick}>Load data</Button>
            </div>
            {data.length === 0 && buttonHasBeenClicked ? <p>No data for this range</p> :
                <LineChart data={data} />}
        </React.Fragment>);
    }
}