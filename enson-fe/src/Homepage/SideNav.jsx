import React, { Component } from "react";

import "./Homepage.css";

// import { Nav, NavDropdown, FormControl, Navbar, Button, Form, Row, Container, Image, Col, Card } from 'react-bootstrap/';

class SideNav extends Component {
  render() {
    return (
      <div id="sideNavBar">
        <div id="userProfile">
          <div>
            <a href="">
              <img
                src="https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-xs-avatar/1083be7085be11e884ba752449095835.jpg"
                alt=""
              />
            </a>
          </div>
          <div id="fullName">
            <span>
              <a href="">
                <strong>Jeremy Tran</strong>
              </a>
            </span>
          </div>
          <div id="username">
            <span>@jeremytran</span>
          </div>
          <div id="analysing" className="row" style={{ margin: 10 }}>
            <div>
              <div>
                <a href="#">
                  <strong>Friends</strong>
                </a>
              </div>
              <div>
                <strong>69</strong>
              </div>
            </div>
            <div>
              <div>
                <a href="#">
                  <strong>Followers</strong>
                </a>
              </div>
              <div>
                <strong>45</strong>
              </div>
            </div>
            <div>
              <div>
                <a href="#">
                  <strong>Following</strong>
                </a>
              </div>
              <div>
                <strong>78</strong>
              </div>
            </div>
          </div>
        </div>
        <div id="listSideNavBarButton">
          <div id="newsFeedButton">
            <i class="fab fa-hotjar" />
            <span href="#">Nỗi bật</span>
          </div>
          <div id="newsFeedButton">
            <i class="fab fa-facebook-messenger" />
            <span>Tin nhắn</span>{" "}
          </div>
          <div id="newsFeedButton">
            <i class="fab fa-hotjar" />
            <span>Bảng tin</span>{" "}
          </div>
        </div>
      </div>
    );
  }
}

export default SideNav;
