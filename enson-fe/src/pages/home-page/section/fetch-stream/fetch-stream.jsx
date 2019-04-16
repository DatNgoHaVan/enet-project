import React, { PureComponent } from "react";

import AddFriendItem from "../../../../components-business/add-friend-suggestion/AddFriendItem";
import "./Homepage";
import AddFriendSuggestion from "../../../../components-business/add-friend-suggestion/AddFriendSuggestion";

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
