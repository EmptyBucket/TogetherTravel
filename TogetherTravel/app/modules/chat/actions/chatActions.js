import ActionsTypes from "../actionsTypes.js";

export function sendMessage(chatReceiverId, message, url) {
    return (dispatch, getState) => {
        dispatch({
            type: ActionsTypes.StartSendMessage,
            chatReceiverId: chatReceiverId,
            message: message
        });
        window.fetch(`${url}?chatReceiverId=${chatReceiverId}&message=${message}`, { method: "POST" })
            .then(res => res.json())
            .then(res =>
                dispatch({
                    type: ActionsTypes.SuccessSendMessage,
                    chatReceiverId: chatReceiverId,
                    message: message
                }))
            .catch(error => dispatch({
                type: ActionsTypes.ErrorSendMessage,
                details: error
            }));
    };
}

export function receiveMessage(userFromId, chatReceiverId, message) {
    return (dispatch, getState) => {
        dispatch({
            type: ActionsTypes.StartReceiveMessage,
            chatReceiverId: chatReceiverId,
            userFromId: userFromId,
            message: message
        });
        dispatch({
            type: ActionsTypes.SuccessReceiveMessage,
            chatReceiverId: chatReceiverId,
            userFromId: userFromId,
            message: message
        });

    };    
}

export function addUserToChat(userId, chatId, url) {
    return (dispatch, getState) => {
        dispatch({
            type: ActionsTypes.StartAddUserToChat,
            userId: userId,
            chatId: chatId
        });
        window.fetch(`${url}?userId=${userId}&chatId=${chatId}`, { method: "POST" })
            .then(res => res.json())
            .then(res => {
                dispatch({
                    type: ActionsTypes.SuccessReceiveMessage,
                    userId: userId,
                    chatId: chatId
                });
            })
            .catch(error => dispatch({
                type: ActionsTypes.ErrorAddUserToChat,
                details: error
            }));
    };
}