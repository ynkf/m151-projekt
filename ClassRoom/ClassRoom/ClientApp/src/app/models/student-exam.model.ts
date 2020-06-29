
import { ExamModel } from 'src/app/models/exam.model';
import { StudentMarkModel } from './student-mark.model';
export class StudentExamModel {
  constructor(
    public exam: ExamModel,
    public student: StudentMarkModel
  ) {}
}
