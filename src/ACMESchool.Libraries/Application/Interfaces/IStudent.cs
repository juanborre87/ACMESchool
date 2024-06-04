using ACMESchool.Libraries.Domain;
using ACMESchool.Libraries.Domain.Entities;
using ACMESchool.Libraries.Infrastructure.Interfaces;

namespace ACMESchool.Libraries.Application.Interfaces
{
    public interface IStudent
    {
        public Task<StudentEntity> Add(StudentEntity entity);
    }
}