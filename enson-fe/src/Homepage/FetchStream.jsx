import React, { PureComponent } from "react";

import AddFriendSuggestion from "../User/AddFriendSuggestion";
import "./Homepage";

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
