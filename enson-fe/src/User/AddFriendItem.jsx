import React, { PureComponent } from "react";
import "./User.css";
class AddFriendItem extends PureComponent {
  render() {
    return (
      <div id="addFriendCard" className="row">
        <div style={{ width: "200px" }} className="row">
          <div id="suggestedFriendAvatar">
            <img
              src="https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-xs-avatar/a5341540d1b111e78c55814e5899e694.jpg"
              alt=""
            />
          </div>
          <div style={{ marginLeft: "10px" }}>
            <div id="suggestedFriendName">
              <a href="/user/#">
                <strong>Anthony</strong>
              </a>
              <span>( Tấn Tài )</span>
            </div>
            <div id="mutualFriendNumber">
              <a href="">5 bạn chung.</a>
            </div>
          </div>
        </div>

        <div style={{ width: "150px" }}>
          <div id="addFriendButton" >Add</div>
        </div>
      </div>
    );
  }
}
export default AddFriendItem;
