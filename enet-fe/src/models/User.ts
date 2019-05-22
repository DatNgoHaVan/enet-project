class User {
  private _id: string;
  private _username: string;
  private _passwordSalt: string;
  private _passwordHash: string;
  private _firstName: string;
  private _lastName: string;
  private _address: string;
  private _birthday: Date;
  private _phoneNumber: string;
  private _email: string;
  private _roleId: string;

  constructor(
    id: string,
    username: string,
    passwordSalt: string,
    passwordHash: string,
    firstName: string,
    lastName: string,
    address: string,
    birthday: Date,
    phoneNumber: string,
    email: string,
    roleId: string
  ) {
    this._id = id;
    this._username = username;
    this._passwordSalt = passwordSalt;
    this._passwordHash = passwordHash;
    this._firstName = firstName;
    this._lastName = lastName;
    this._address = address;
    this._birthday = birthday;
    this._phoneNumber = phoneNumber;
    this._email = email;
    this._roleId = roleId;
  }

  get id(): string {
    return this._id;
  }

  get username(): string {
    return this._username;
  }

  get passwordSalt() {
    return this._passwordSalt;
  }
  set passwordSalt(newPasswordSalt: string) {
    this._passwordSalt = newPasswordSalt;
  }

  get passwordHash() {
    return this._passwordHash;
  }
  set passwordHash(newPasswordHash: string) {
    this._passwordHash = newPasswordHash;
  }

  get firstName() {
    return this._firstName;
  }
  set firstName(newFirstName: string) {
    this._firstName = newFirstName;
  }

  get lastName() {
    return this._lastName;
  }
  set lastName(newLastName: string) {
    this._lastName = newLastName;
  }
  get fullName() {
    return this._lastName + " " + this._firstName;
  }
  get address() {
    return this._address;
  }
  set address(newAddress: string) {
    this._address = newAddress;
  }

  get birthday() {
    return this._birthday;
  }
  set birthday(newBirthday: Date) {
    this._birthday = newBirthday;
  }

  get email() {
    return this._email;
  }
  set email(newEmail: string) {
    this._email = newEmail;
  }

  get roleId() {
    return this._roleId;
  }
  set roleId(newRoleId) {
    this._roleId = newRoleId;
  }
}
