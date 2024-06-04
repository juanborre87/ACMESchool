using ACMESchool.Libraries.Application.Interfaces;
using ACMESchool.Libraries.Application.Models;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Student;
using ACMESchool.Libraries.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Course
{
    public class CreateCourseCommand : IRequest<Response<CreateCourseResponse>>
    {
        public string Name { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateCourseHandler(ICourse repository) : IRequestHandler<CreateCourseCommand, Response<CreateCourseResponse>>
    {
        public async Task<Response<CreateCourseResponse>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {

            if (request != null)
            {
                var result = await repository.Add(new CourseEntity
                {
                    Name = request.Name,
                    RegistrationFee = request.RegistrationFee,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,                    
                });

                return new Response<CreateCourseResponse>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new()
                    {
                        Id = result.Id,
                        Name = result.Name,
                        RegistrationFee = result.RegistrationFee,
                        StartDate = result.StartDate,
                        EndDate = result.EndDate,
                    },
                };
            }

            return new Response<CreateCourseResponse>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Notifications = { new Notify
                        {
                            Code = ((int)HttpStatusCode.BadRequest).ToString(),
                            Message = "No Success"
                        } }
            };

        }
    }
}
