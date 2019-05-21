import React, { Component } from "react";
import { history } from "../../redux/history";

import "./home-page.css";
import TopNav from "../../components-business/top-nav/top-nav";
import Post from "../../components-business/post/post";
import SideNav from "../../components-business/side-nav/side-nav";
import CreatePost from "../../components-business/post/create-post";
import FetchStream from "./section/fetch-stream/fetch-stream";

class Homepage extends Component {
  constructor(props) {
    super(props);
    this.logout = this.logout.bind(this);
  }

  logout() {
    localStorage.removeItem("token");
    history.push("/");
  }

  render() {
    return (
      <div>
        <div id="navbar">
          <TopNav />
        </div>
        <div className="row" id="mainContainer">
          <div id="leftContainer">
            <SideNav />
          </div>
          <div id="feedStream">
            <CreatePost />
            <Post />
            <Post />
          </div>
          <div id="feactStream">
            <FetchStream />
          </div>
          <div id="rightContainer" />
        </div>
      </div>
    );
  }
}

export default Homepage;
