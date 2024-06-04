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
    public class StudentService : IStudent
    {
        private readonly IRepository<StudentEntity> _repository;
        public StudentService()
        {
            _repository = new Repository<StudentEntity>();
        }
        public async Task<StudentEntity> Add(StudentEntity student)
        {
            student.Id = new Random().Next(0, 1000);
            await _repository.AddAsync(student);
            return student;
        }
    }
}
