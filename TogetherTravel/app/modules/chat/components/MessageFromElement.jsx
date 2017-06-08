import React from "react";
import Message from "./messageElement.jsx";

export default class MessageFrom extends React.Component {
    render() {
        return (
            <Message>
                <div>
                    {this.props.dateCreated} - {this.props.author}
                </div>
                <div>
                    {this.props.message}
                </div>
            </Message>);
    }
}
