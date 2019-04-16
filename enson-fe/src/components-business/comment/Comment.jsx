import React, { Component } from "react";

import "../post/post.css";

class Comment extends Component {
  render() {
    return (
      <div className="comment grid-container">
        <div className="user-avatar grid-item">
          <a href="/user/#">
            <img
              src="https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-xs-avatar/a5341540d1b111e78c55814e5899e694.jpg"
              alt=""
            />
          </a>
        </div>
        <div className="user-comment grid-item">
          <a href="/user/#">
            <b>Anthony</b>
          </a>
          <span>
            If you request removal of all security info in your account, the
            info doesn’t actually change for 30 days. During this time, we
            cannot accept further changes or additions to security settings or
            billing info. Your account is still open and active, and you can
            still use your email, Skype, OneDrive, and devices as usual. We’ll
            let you know when it's time to enter new security info.
          </span>
          <div>
            <small style={{ fontSize: 11 }}>2 phút trước</small>
          </div>
        </div>
        <div id="commentOption">
          <a href="#">
            <i className="fas fa-ellipsis-h" />
          </a>
        </div>
      </div>
    );
  }
}

export default Comment;
