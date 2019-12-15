import React, { Component } from 'react';
import { XYPlot, XAxis, YAxis, VerticalGridLines, LineSeries, HorizontalGridLines } from 'react-vis';

export default class LineChart extends Component {
    MSEC_DAILY = 86400000;

    render() {
        const {data} = this.props;       
        return (
            <XYPlot
                xType="time"
                width={1000}
                height={300}
                getX={d => new Date(d.date)}
                getY={d => d.attendancePercentage}
                yDomain={[0, 100]}>
                <HorizontalGridLines />
                <VerticalGridLines />
                <XAxis title="Date"  tickTotal={data.length/2}  tickFormat={value =>value.toISOString().slice(0, 10)} />
                <YAxis title="Attendance percentage" />
                <LineSeries
                    data={data} />
            </XYPlot>
        );
    }
}