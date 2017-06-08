import React from "react";

export default class Details extends React.Component {
    render() {
        return (
            <div className="form-horizontal">
                <div className="form-group">
                    <label className="control-label col-xs-4">
                        Дата рождения:
                    </label>
                    <div className="col-xs-8">
                        {this.props.birthDay}
                    </div>
                </div>
                <div className="form-group">
                    <label className="control-label col-xs-4">
                        Статус:
                    </label>
                    <div className="col-xs-8">
                        {this.props.status}
                    </div>
                </div>
            </div>);
    }
}