import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as PrivateChatActions from "../../actions/chat.js";
import ReactCssTransitionGroup from "react-addons-transition-group"
import MessageFrom from "./messageFromElement.jsx";
import MessageTo from "./messageToElement.jsx";
import MessageInput from "./messageImportElement.jsx";

class PrivateChat extends React.Component {
    render() {
        const messages = this.props.messages.map(message => message.from
            ? <MessageFrom />
            : <MessageTo />);
        return (
            <div>
                <ReactCssTransitionGroup>
                    {messages}
                </ReactCssTransitionGroup>
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