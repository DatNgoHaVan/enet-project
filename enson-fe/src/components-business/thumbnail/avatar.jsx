import React, { Component } from "react";
import classNames from "classnames";
import "./avatar.css";

class Avatar extends Component {
  render() {
    return (
      <a href={props.href}>
        <img
          width={props.width}
          src={props.user.avatarUrl}
          alt={props.user.name}
        />
      </a>
    );
  }
}

export default Avatar;
