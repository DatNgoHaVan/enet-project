class PostComment {
  constructor(
    id: string,
    createTime: string,
    mediaUrl: string,
    content: string,
    userId: string,
    postId: string
  ) {
    this._id = id;
    this._createTime = createTime;
    this._mediaUrl = mediaUrl;
    this._content = content;
    this._userId = userId;
    this._postId = postId;
  }
  private _id: string;
  public get id_1(): string {
    return this._id;
  }
  public set id_1(value: string) {
    this._id = value;
  }
  private _createTime: string;
  public get createTime(): string {
    return this._createTime;
  }
  public set createTime(value: string) {
    this._createTime = value;
  }
  private _mediaUrl: string;
  public get mediaUrl(): string {
    return this._mediaUrl;
  }
  public set mediaUrl(value: string) {
    this._mediaUrl = value;
  }
  private _content: string;
  public get content(): string {
    return this._content;
  }
  public set content(value: string) {
    this._content = value;
  }
  private _userId: string;
  public get userId(): string {
    return this._userId;
  }
  public set userId(value: string) {
    this._userId = value;
  }
  private _postId: string;
  public get postId(): string {
    return this._postId;
  }
  public set postId(value: string) {
    this._postId = value;
  }
}
