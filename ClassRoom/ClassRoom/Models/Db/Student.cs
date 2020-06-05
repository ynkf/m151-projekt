using System;
using System.Collections.Generic;

namespace ClassRoom.Models.Db
{
    public partial class Student
    {
        public Student()
        {
            ClassStudents = new HashSet<ClassStudent>();
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
