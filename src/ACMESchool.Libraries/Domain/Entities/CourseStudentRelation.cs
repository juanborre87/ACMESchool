using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Libraries.Domain.Entities
{
    public class CourseStudentRelation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal RegistrationPayment { get; set; }
        public int CourseId { get; set; }
    }
}
