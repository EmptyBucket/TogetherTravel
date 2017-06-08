import React from "react";

export default class Photo extends React.Component {
    render() {
        return (
            <img src={this.props.photoUrl} alt="photo" />);
    }
}
