import React, { PureComponent } from "react";

import AddFriendItem from "../../../../components-business/add-friend-suggestion/add-friend-item";
import "../../home-page.css";
import AddFriendSuggestion from "../../../../components-business/add-friend-suggestion/add-friend-suggestion";

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
