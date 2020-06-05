using System;
using System.Collections.Generic;

namespace ClassRoom.Models.Db
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int? Mark1 { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
    }
}
