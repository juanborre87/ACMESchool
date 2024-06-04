using ACMESchool.Libraries.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ACMESchool.Libraries.Domain;
using ACMESchool.Libraries.Domain.Entities;
using ACMESchool.Libraries.Application.Models;


namespace ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Student
{
    public class CreateStudentCommand : IRequest<Response<CreateStudentResponse>>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class CreateStudentHandler(IStudent repository) : IRequestHandler<CreateStudentCommand, Response<CreateStudentResponse>>
    {
        public async Task<Response<CreateStudentResponse>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {

            if (request != null)
            {
                if (request.Age < 18)
                {
                    return new Response<CreateStudentResponse>()
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Notifications = { new Notify
                        {
                            Code = ((int)HttpStatusCode.BadRequest).ToString(),
                            Message = "Only adults can be registered"
                        } }

                    };
                }

                var result = await repository.Add(new StudentEntity
                {
                    Age = request.Age,
                    Name = request.Name
                });

                return new Response<CreateStudentResponse>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new CreateStudentResponse() 
                    { 
                        Id = result.Id,
                        Name = result.Name,
                        Age = result.Age
                    },
                };
            }

            return new Response<CreateStudentResponse>()
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
