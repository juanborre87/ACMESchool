using ACMESchool.Libraries.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Libraries.Application.UseCases.SchoolOperation.Queries.Course.GetList
{
    public class ListCourseResponse
    {
        public List<CourseEntity> CourseEntities { get; set; }
    }
}
