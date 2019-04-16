import React, { Component } from "react";
import { history } from "../../redux/History";

import "./Homepage.css";
import TopNav from "../../components-business/top-nav/TopNav";
import Post from "../../components-business/post/Post";
import SideNav from "../../components-business/side-nav/SideNav";
import CreatePost from "../../components-business/post/CreatePost";
import FetchStream from "./section/fetch-stream/FetchStream";
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
