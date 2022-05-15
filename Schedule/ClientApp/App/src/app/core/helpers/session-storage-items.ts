export class SessionStorageItems {
  static currentUser = new SessionStorageItems('currentUser');

  constructor(public value: string) { }

  toString() {
    return this.value;
  }
}
