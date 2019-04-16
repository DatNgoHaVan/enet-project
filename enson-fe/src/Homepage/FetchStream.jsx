import React, { PureComponent } from "react";

import AddFriendItem from "../User/AddFriendItem";
import "./Homepage";
import AddFriendSuggestion from "../User/AddFriendSuggestion";

class FetchStream extends PureComponent {
  render() {
    return (
      <div style={{margin:"10px"}}> 
        <AddFriendSuggestion />
      </div>
    );
  }
}
export default FetchStream;
