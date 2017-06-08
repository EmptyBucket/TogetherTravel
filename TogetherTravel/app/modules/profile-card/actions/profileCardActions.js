import * as ActionsTypes from "../actionsTypes.js";
import CamelCaseToLowerCamelCaseConverter from "../../../common/camelCaseToLowerCamelCaseConverter.js";

export function loadUser(userId, url) {
    return (dispatch, getState) => {
        dispatch({
            type: ActionsTypes.StartUserLoad,
            userId: userId
        });
        window.fetch(url + "?userId=" + userId, { method: "POST" })
            .then(res => res.json())
            .then(res => {
                var convertedObj = CamelCaseToLowerCamelCaseConverter.convert(res);
                var action = Object.assign({
                        type: ActionsTypes.SuccessUserLoad
                    },
                    convertedObj);
                dispatch(action);
            })
            .catch(error => dispatch({
                type: ActionsTypes.ErrorUserLoad,
                details: error
            }));
    };
}