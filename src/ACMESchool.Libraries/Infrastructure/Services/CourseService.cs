using ACMESchool.Libraries.Application.Interfaces;
using ACMESchool.Libraries.Domain.Entities;
using ACMESchool.Libraries.Infrastructure.Interfaces;
using ACMESchool.Libraries.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Libraries.Infrastructure.Services
{
    public class CourseService : ICourse
    {
        private readonly IRepository<CourseEntity> _repository;
        public CourseService()
        {
            _repository = new Repository<CourseEntity>();
        }

        public async Task<CourseEntity> Add(CourseEntity student)
        {
            student.Id = new Random().Next(0, 1000); ;
            await _repository.AddAsync(student);
            return student;
        }

        public async Task<List<CourseEntity>> GetCourseAsync(Func<CourseEntity, bool> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }

    }
}
