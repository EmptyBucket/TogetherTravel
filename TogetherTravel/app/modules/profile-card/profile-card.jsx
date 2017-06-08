require("./index.css");
import { render } from "react";
import { createStore, applyMiddleware } from "redux";
import Provider from "react-redux";
import Thunk from "redux-thunk";
import RootReducer from "./rootReducer.js";
import ProfileCard from "./components/profileCardComponent.js";

export default function (options) {
    const elem = options.elem;
    const store = createStore(RootReducer, applyMiddleware(Thunk));

    function render() {
        return (
            <Provider store={store}>
                <ProfileCard userId={options.userId} url={options.url} />
            </Provider>, elem);
    }

    render();
}