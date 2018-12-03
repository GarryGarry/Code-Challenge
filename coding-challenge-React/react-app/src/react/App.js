import React, { Component } from 'react';
import Events from './components/Events';
import axios from 'axios';
import './App.css';
import img3 from './img/horse.JPG';
import img1 from './img/img1.png';

const styleTable = {
    borderCollapse: 'collapse',
    width: '55%',
    textAlign: 'left',
    margin: '10rem',
    borderBottom: '1px solid #ddd'
};


class App extends Component {
    constructor(props) {
        super(props)
        this.state = {
            data: [],
            error: false
        }
    }

    componentDidMount() {
        axios.get('https://s3-ap-southeast-2.amazonaws.com/bet-easy-code-challenge/next-to-jump')
            .then(res => {
                this.setState({ data: res.data.result})
            })
            .catch(error => {
                this.setState({ error: true });
            });
    }
    render() {
        let data = this.state.data;
        let eventDetails = null;

        if (this.state.error) {
            eventDetails = <p>somehting went wrong Check url!</p>
        } else {
            eventDetails = Object.keys(data)
                .map(eventKey => {
                    return (<Events key={eventKey} event={data[eventKey]} />)
                });
        }
        return (
            <div className="ui one column stackable center aligned page grid">
                <div className="column sixteen wide">
                    <div className="ui segment" style={styleTable}>
                        <div className="ui icon header">
                            <div class="ui segment">
                                <div className="ui two column very relaxed grid">
                                    <div className="column">
                                        <span className="Logo"> <h2><img src={img1} className="Image" /></h2> </span>
                                    </div>
                                    <div className="column">
                                        <img src={img3} className="Horse" /><h3 >Racing</h3>
                                    </div>
                                    <div class="ui vertical divider"> </div>
                                </div>
                            </div>
                            <div class="ui segment">
                            <div className="Title"><h2 className="Jump">Next to Jump</h2></div>
                            <table className="Table" >
                                {eventDetails}
                            </table>
                        </div>
                        </div>
                    </div>
                </div>
            </div>

        );
    }
}

export default App;
