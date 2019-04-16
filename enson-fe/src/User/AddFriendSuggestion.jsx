import React, { PureComponent } from "react";
import "./User.css";
import AddFriendItem from "./AddFriendItem";
class AddFriendSuggestion extends PureComponent {
  render() {
    return (
      <div id="addFriendSuggestion">
        <div id="addFriendSuggestionTitle">
          <span>
            <strong>Những người có thể bạn biết</strong>
          </span>
          <a href="#">
            <i className="fas fa-ellipsis-h" />
          </a>
        </div>
        <div id="addFriendSuggestionList" />
        <AddFriendItem />
        <div />
      </div>
    );
  }
}

export default AddFriendSuggestion;
