import React from "react";

export default class MessageInput extends React.Component {
    constructor(props) {
        super(props);
        this.state = { text: "" };
    }
    textChange(e) {
        this.setState({ text: e.target.textContent });
    }
    sendMessage() {
        this.actions.sendMessage(this.props.sendMessageUrl, this.ptops.chatId, this.state.text);
    }
    render() {
        return (
            <div>
                <textarea onChange={this.messageChange.bind(this)}>
                    {this.state.text}
                </textarea>
                <button type="button">
                </button>
            </div>);
    }
}
