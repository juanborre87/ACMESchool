using ACMESchool.Libraries.Application.Interfaces;
using ACMESchool.Libraries.Application.Models;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Course;
using ACMESchool.Libraries.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.CourseStudent
{
    public class ContractCourseCommnad : IRequest<Response<string>>
    {
        public int StudentId { get; set; }
        public decimal RegistrationPayment { get; set; }
        public int CourseId { get; set; }
    }

    public class ContractCourseHandler(ICourseStudentRelation repository, IPaymentGateway _paymentGateway) : IRequestHandler<ContractCourseCommnad, Response<string>>
    {
        public async Task<Response<string>> Handle(ContractCourseCommnad request, CancellationToken cancellationToken)
        {

            if (request != null)
            {
                var result = await repository.Add(new CourseStudentRelation
                {
                    CourseId = request.CourseId,
                    StudentId = request.StudentId,
                    RegistrationPayment = request.RegistrationPayment
                });

                return new Response<string>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Notifications = { new Notify
                        {
                            Code = ((int)HttpStatusCode.BadRequest).ToString(),
                            Message = "Success"
                        } }
                };
            }

            return new Response<string>()
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
