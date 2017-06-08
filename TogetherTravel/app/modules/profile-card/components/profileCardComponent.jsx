import React from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as ProfileCardActions from "../actions/profileCardActions.js";
import Photo from "photoElement.jsx";
import Header from "headerElement.jsx";
import Details from "detailsElement.jsx";

class ProfileCard extends React.Component {
    constructor(userId, url) {
        super(props);
        this.loadUser(userId, url);
    }
    render() {
        return (
            <div className="container-fluid">
                <div className="row">
                    <div className="col-xs-6">
                        <Photo />
                    </div>
                    <div className="col-xs-6">
                        <Header />
                        <Details />
                    </div>
                </div>
            </div>);
    }
}

function mapStateToProps(state) {
    return state;
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(ProfileCardActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(ProfileCard);