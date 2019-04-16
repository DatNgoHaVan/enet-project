import React, { Component } from "react";
import "./Post.css";
import Comment from "../comment/Comment";
import CommentBox from "../comment/CreateComment";
class Post extends Component {
  constructor(props) {
    super(props);
    this.state = {
      author: {
        id: 69,
        name: "Jeremy",
        avatarUrl:
          "https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-xs-avatar/1083be7085be11e884ba752449095835.jpg"
      },
      post: {
        id: 1,
        createdTime: 3,
        content:
          "If you request removal of all security info in your account, the info doesn’t actually change for 30 days. During this time, we cannot accept further changes or additions to security settings or billing info. Your account is still open and active, and you can still use your email, Skype, OneDrive, and devices as usual. We’ll let you know when it's time to enter new security info.",
        url:
          "https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-images/bc51a76053d811e98770172f3f62aafa.jpg",
        like: 16,
        dislike: 69,
        share: 54
      }
    };
  }
  render() {
    const { author, post } = this.state;
    const authorUrl = "/user/" + author.id;

    return (
      <div id="post">
        <div className="row" style={{ marginLeft: "15px" }}>
          <div id="postHeader" className="row">
            <div id="postAuthorAvatar" className="author-avatar">
              <a href={authorUrl}>
                <img src={author.avatarUrl} alt="Avatar" />
              </a>
            </div>
            <div id="postAuthorInfo">
              <div>
                <a href="/user/#userId" id="authorName">
                  <b>Jeremy</b>
                </a>
              </div>
              <div>
                <a className="createdDate" href="/post/#postId">
                  23 phút trước
                </a>
                <a href="#">
                  <i className="fas fa-globe-asia leftOf" />
                </a>
              </div>
            </div>
          </div>
          <div id="postOption">
            <a href="#">
              <i className="fas fa-ellipsis-h" />
            </a>
          </div>
        </div>
        <div className="post-content">
          <div className="post-document">
            <p>
              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus
              imperdiet, nulla et dictum interdum, nisi lorem egestas vitae scel
            </p>
          </div>
          <div className="post-media">
            <img
              src="https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-images/bc51a76053d811e98770172f3f62aafa.jpg"
              // src="https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-images/0109d12053d911e9a76669430317bbc5.jpg"
              alt="Post Image"
            />
          </div>
        </div>

        <div id="post-interacting" className="row">
          <div style={{ margin: "0 auto" }}>
            <a class="btn love  " href="#">
              <i class="fas fa-heart" />
              <span className="count">12</span>
            </a>
            <a class="btn sad " href="#" style={{ marginRight: "20px" }}>
              <i class="fas fa-heart-broken" />
              <span className="count">69</span>
            </a>
            <a
              href="#"
              className="btn share active"
              style={{ marginLeft: "20px" }}
            >
              <i class="fas fa-share">
                <span className="count">65</span>
              </i>
            </a>
            <a href="#" className="btn comment active">
              <i class="fas fa-comments">
                <span className="count">16</span>
              </i>
            </a>
          </div>
        </div>
        <div className="post-comment-box">
          <CommentBox />
        </div>
        <div className="post-comment">
          <Comment />
          <Comment />
        </div>
      </div>
    );
  }
}

export default Post;
