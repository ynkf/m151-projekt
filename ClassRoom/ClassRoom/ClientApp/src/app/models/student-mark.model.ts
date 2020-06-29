export class StudentMarkModel {
  constructor(
    public studentId: number,
    public lastName: string,
    public firstName: string,
    public mark?: number
  ) {}
}
