using System;
using System.Collections.Generic;

namespace ClassRoom.Models.Db
{
    public partial class Teacher
    {
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
