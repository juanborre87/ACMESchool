using ACMESchool.Libraries.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Libraries.Application.Interfaces
{
    public interface ICourseStudentRelation
    {
        Task<CourseStudentRelation> Add(CourseStudentRelation entity);
    }
}
