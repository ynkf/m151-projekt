namespace ClassRoom.Models.TransferModels
{
    public class StudentExamTransferModel
    {
        public StudentExamTransferModel(ExamTransferModel exam, StudentMarkTransferModel student)
        {
            Exam = exam;
            Student = student;
        }

        public ExamTransferModel Exam { get; set; }
        public StudentMarkTransferModel Student { get; set; }
    }
}
