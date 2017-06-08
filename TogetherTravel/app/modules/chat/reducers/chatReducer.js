import * as ActionsTypes from "../actionsTypes.js";

const initState = {
    messages: [],
    users: []
};

export default function(state = initState, action) {
    switch(action.type) {
        case ActionsTypes.SuccessReceiveMessage:
        case ActionsTypes.SuccessSendMessage:
            {
                
            }
        case ActionsTypes.SuccessAddUserToChat:
            {
                
            }
        default:
            return state;
    };
}