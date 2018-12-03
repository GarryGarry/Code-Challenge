import React, { Component } from 'react';
import moment from 'moment';
import './Events.css';
import img3 from '../img/horse.JPG';

class Events extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        console.log(this.props.event);
        let event = this.props.event;
        let Time = moment(event.AdvertisedStartTim).format("hh:mm:ss a");
        let Date = moment(event.AdvertisedStartTim).format('DD-MMM-YYYY');

        return (
            <tbody className="TableData" >
                <tr>
                    <td style={{ width: '5px' }}> <img src={img3} className="SmallHorse" /> </td>
                    <td >{event.EventName}</td>
                    <td >{event.Venue.Venue}</td>
                    <td >{Time}</td>

                </tr>
            </tbody>

        );
    }
}

export default Events;
