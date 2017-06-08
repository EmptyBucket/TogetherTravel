import React from "react";
import Message from "./messageElement.js";

export default class MessageTo extends React.Component {
    render() {
        return (
            <Message>
                <div>
                    {this.ptops.dateCreated} - {this.props.author}
                </div>
                <div>
                    {this.props.message}
                </div>
            </Message>);
    }
}
