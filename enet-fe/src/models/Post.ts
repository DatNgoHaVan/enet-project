class Post {
  private _id: string;
  public get id(): string {
    return this._id;
  }
  public set id(value: string) {
    this._id = value;
  }
  private _type: string;
  public get type_1(): string {
    return this._type;
  }
  public set type_1(value: string) {
    this._type = value;
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
  private _status: string;
  public get status(): string {
    return this._status;
  }
  public set status(value: string) {
    this._status = value;
  }
  private _userId: string;
  public get userId(): string {
    return this._userId;
  }
  public set userId(value: string) {
    this._userId = value;
  }
  private _createdTime: Date;
  public get createdTime(): Date {
    return this._createdTime;
  }
  public set createdTime(value: Date) {
    this._createdTime = value;
  }
  private _avaliableOptionId: string;
  public get avaliableOptionId(): string {
    return this._avaliableOptionId;
  }
  public set avaliableOptionId(value: string) {
    this._avaliableOptionId = value;
  }
  
  constructor(
    id: string,
    type: string,
    mediaUrl: string,
    content: string,
    status: string,
    userId: string,
    createdTime: Date,
    avaliableOptionId: string
  ) {
    this._id = id;
    this._type = type;
    this._mediaUrl = mediaUrl;
    this._content = content;
    this._status = status;
    this._userId = userId;
    this._createdTime = createdTime;
    this._avaliableOptionId = avaliableOptionId;
  }
}
