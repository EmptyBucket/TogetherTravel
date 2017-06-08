import React from "react";

export default class Header extends React.Component {
    render() {
        return (
            <div>
                <div className="text-center">
                    {this.props.nickName}
                </div>
                <div className="text-center">
                    {this.props.firstName} {this.props.secondname}
                </div>
            </div>);
    }
}
