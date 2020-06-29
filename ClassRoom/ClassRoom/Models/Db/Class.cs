using System;
using System.Collections.Generic;

namespace ClassRoom.Models.Db
{
    public partial class Class
    {
        public Class()
        {
            ClassStudents = new HashSet<ClassStudent>();
            Exams = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
