import * as ActionsTypes from "../actionsTypes.js";

const initState = {};

export default function(state = initState, action) {
    switch(action.type) {
        case ActionsTypes.LoadUser:
            {
                return Object.assign({}, state,
                    {
                        photoUrl: action.photoUrl,
                        id: action.id,
                        nickName: action.nickName,
                        firstName: action.firstName,
                        secondName: action.secondname,
                        birthDay: action.birthDay,
                        status: action.status
                    });
            }
        default:
            return state;
    }
}