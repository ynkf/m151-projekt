export class UserModel {
  constructor(
    public id: number,
    public userId: number,
    public lastName: string,
    public firstName: string,
    public email: string,
    public userType: UserTypes,
    public isLoggedIn: boolean = false
   ) {}
}

export enum UserTypes {
  User,
  Student,
  Teacher
}
