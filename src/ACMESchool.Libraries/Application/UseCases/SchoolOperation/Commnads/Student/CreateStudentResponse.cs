using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Student
{
    public class CreateStudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
