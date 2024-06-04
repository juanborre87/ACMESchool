using ACMESchool.Libraries.Domain.Entities;
using ACMESchool.Libraries.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Libraries.Application.Interfaces
{
    public interface ICourse
    {
        Task<CourseEntity> Add(CourseEntity entity);
        public Task<List<CourseEntity>> GetCourseAsync(Func<CourseEntity, bool> predicate);
    }
}
