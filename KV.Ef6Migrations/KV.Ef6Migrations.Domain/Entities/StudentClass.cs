using System;
using System.Collections.Generic;

namespace KV.Ef6Migrations.Domain.Entities
{
    public class StudentClass
    {
        public StudentClass()
        {
            StudentList = new List<Student>();
        }

        public Guid StudentClassId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> StudentList { get; set; }

        public override string ToString()
        {
            return String.Format("Turma: {0} - Data Início: {1} - Professor: {2}", Course.Description, InitialDate.ToShortDateString(), Teacher.Name);
        }

    }
}