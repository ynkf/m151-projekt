export class ClassModel {
  constructor(
    public id: number,
    public teacherId: number,
    public name: string,
    public isExpanded = false
  ) {}
}
