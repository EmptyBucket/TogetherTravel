import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as PrivateChatActions from "../../actions/privateChat.js";
import ReactCssTransitionGroup from "react-addons-transition-group"

class MessageFrom extends React.Component {
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

class MessageTo extends React.Component {
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

class Message extends React.Component {
    render() {
        return (
            <div>
                {this.props.children}
            </div>);
    }
}

class MessageInput extends React.Component {
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

class PrivateChat extends React.Component {
    render() {
        const messages = this.props.messages.map(message => message.from ? <MessageFrom/> : <MessageTo/>);
        return (
            <div>
                <div>
                    {messages}
                </div>
                <MessageInput/>
            </div>);
    }
}

function mapStateToProps(state) {
    return {
        curUsername: state.curUserName,
        chats: state.chats
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(PrivateChatActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(PrivateChat);