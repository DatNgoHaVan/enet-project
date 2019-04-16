import React, { PureComponent } from "react";

import "./post.css";

class CreatePost extends PureComponent {
  constructor(props) {
    super(props);
    this.state = {
      user: {
        id: 69,
        avatarUrl:
          "https://s3-ap-southeast-1.amazonaws.com/img.spiderum.com/sp-xs-avatar/1083be7085be11e884ba752449095835.jpg"
      },
      post: {
        id: "",
        type: null,
        url: null,
        content: null,
        status: null,
        userId: null,
        availableOption: null
      },
      focus: false,
      postValue: "",
      hasValue: false
    };
    this.onFocusPostBox = this.onFocusPostBox.bind(this);
    this.onLeavePostBox = this.onLeavePostBox.bind(this);
    this.onPostContentChange = this.onPostContentChange.bind(this);
    this.getPostHintText = this.getPostHintText.bind(this);
  }
  getPostHintText() {
    return this.state.post.name + " ơi, bạn đang nghĩ gì vậy!";
  }

  onPostContentChange(e) {
    this.setState({
      post: { ...this.setState.post, content: e.currentTarget.textContent }
    });
  }
  onFocusPostBox(e) {
    this.setState({ focus: true });
    if (e.value === "") {
    }
  }

  onLeavePostBox(e) {
    this.setState({ focus: false });
  }

  onChange(e) {}
  render() {
    const { name, hasValue, post, user } = this.state;
    // console.log(value);
    const hintText = this.getPostHintText();
    const userUrl = "/user/" + user.id;
    return (
      <div id="createPost">
        <div id="createPostTitle">Tạo bài viết</div>
        <div id="createPostBox" className="row">
          <div className="author-avatar" id="createPostAuthor">
            <a href={userUrl}>
              <img src={user.avatarUrl} alt="" />
            </a>
          </div>
          <div id="postTextContainer">
            <div
              id="postText"
              contentEditable="true"
              onFocus={this.onFocusPostBox}
              onBlur={this.onLeavePostBox}
              onChange={this.onPostContentChange}
              // onChange={e =>
              //   this.setState({ value: e.currentTarget.textContent })
              // }
            >
              {/* {focus ? value : (value==""?createPostHintText:value)} */}
            </div>
          </div>
          <div id="contentOption">
            <div className="btn" id="uploadImageButton">
              <i class="fas fa-images" />
              <span>
                <b>Ảnh</b>
              </span>
            </div>
            <div className="btn" id="uploadImageButton">
              <i class="fas fa-user-tag" />
              <span>
                <strong>Gắn thẻ bạn bè</strong>
              </span>
            </div>
            <div className="btn" id="visiableOptionDropButton">
              <i class="fas fa-globe-asia" />
              <span>
                <strong>Công khai</strong>
              </span>
            </div>
            <div className="btn" id="postPublishButton">
              <strong>Đăng</strong>
            </div>
          </div>
        </div>
        <div />
      </div>
    );
  }
}

export default CreatePost;
