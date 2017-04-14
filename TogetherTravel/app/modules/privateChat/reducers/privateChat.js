import * as ActionTypes from "../actionsTypes.js";

const initState = {
    curUserName: "",
    chats: []
}

export default function(state = initState, action) {
    switch(action.type) {
        case ActionTypes.SendMessage:
        case ActionTypes.ReceiveMessage:
            {
                const chat = state.chats.slice(chats.findIndex(chat => chat.id === action.chatId), 1);
                const newChat = Object.assign({},
                    chat,
                    {
                        messages: [ ...chat.messages, action.message ]
                    });
                return Object.assign({},
                    state,
                    {
                        chats: [
                            ...state.chats.filter(chat => chat.id !== action.chatId),
                            newChat
                            ]
                    });
            }
        case ActionTypes.AddChat:
            {
                return Object.assign({},
                    state,
                    {
                        chats: [...state.chats, action.chat]
                    });
            }
        case ActionTypes.RemoveChat:
            {
                return Object.assign({},
                    state,
                    {
                        chats: state.chats.filter(chat => chat.id !== action.chatId)
                    });
            }
        default:
            return state;
    };
}