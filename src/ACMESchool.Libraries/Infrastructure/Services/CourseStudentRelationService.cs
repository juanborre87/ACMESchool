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
    public class CourseStudentRelationService : ICourseStudentRelation
    {
        private readonly IRepository<CourseStudentRelation> _repository;
        public CourseStudentRelationService()
        {
            _repository = new Repository<CourseStudentRelation>();
        }
        public async Task<CourseStudentRelation> Add(CourseStudentRelation courseStudent)
        {
            courseStudent.Id = new Random().Next(0, 1000); ;
            await _repository.AddAsync(courseStudent);
            return courseStudent;
        }
    }
}
