using System;
using System.Collections.Generic;

namespace ClassRoom.Models.Db
{
    public partial class Exam
    {
        public Exam()
        {
            Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
