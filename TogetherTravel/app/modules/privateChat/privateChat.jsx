require("./privateChat.css");
import React from "react";
import { render } from "react-dom";
import { createStore, applyMiddleware } from "redux";
import Provider from "react-redux";
import Thunk from "redux-thunk";

import RootReducer from "./rootReducer.js";
import PrivateChat from "./components/privateChat/privateChat.jsx";

export default function(options) {
    const elem = options.elem;
    const store = createStore(RootReducer, applyMiddleware(Thunk));

    function render() {
        elem.classList.add("private-chat");
        render(
            <Provider store={store}>
                <PrivateChat/>
            </Provider>, elem);        
    }

    render();
}

