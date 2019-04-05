import React, { PureComponent } from "react";
import "./User.css";
class AddFriendButton extends PureComponent {
  render() {
    return (
      <div className="row" id="addFriendCard">
        <div>
          <div id="suggestedFriendAvatar">
            <img
              src="https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-xs-avatar/a5341540d1b111e78c55814e5899e694.jpg"
              alt=""
            />
          </div>
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
        <div style={{marginLeft:20}}>
          <div id="addFriendButton"  >
            <i class="fas fa-user-plus" />
            <span>Kết bạn</span>
          </div>
          <div id="removeSuggestButton" >
            <span>Xóa, gở bỏ</span>
          </div>
        </div>
      </div>
    );
  }
}
export default AddFriendButton;
