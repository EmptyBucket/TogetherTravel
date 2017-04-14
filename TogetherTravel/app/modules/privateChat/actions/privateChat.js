import ActionsTypes from "../actionsTypes.js";

export function getChats(url) {
    return (dispatch, getState) => {
        $.post(url,
            function(e) {
                dispatch({
                    type: ActionsTypes.GetChats,
                    chats: chats
                });
            });
    };
}

export function sendMessage(url, message, chatId) {
    return (dispatch, getState) => {
        $.post(url, { message: message, chatId: chatId },
            function(e) {
                dispatch({
                    type: ActionsTypes.SendMessage,
                    message: message,
                    chatId: chatId
                    });
            });
        };
};

export function receiveMessage(message, chatId) {
    return {
        type: ActionsTypes.ReceiveMessage,
        message: message,
        chatId
    };
};

export function addChat(url, chat) {
    return (dispatch, getState) => {
        $.post(url, { chat },
            function(e) {
                dispatch({
                    type: ActionsTypes.AddChat,
                    chat: chat
                    });
            });
        };
};

export function removeChat(url, chatId) {
    return (dispatch, getState) => {
        $.post(url, { chatId: chatId },
            function(e) {
                dispatch({
                    type: ActionsTypes.RemoveChat,
                    chatId: chatId
                });
            });
        };
};