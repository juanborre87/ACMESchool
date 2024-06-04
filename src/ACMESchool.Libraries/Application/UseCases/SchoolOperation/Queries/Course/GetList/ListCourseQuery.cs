using ACMESchool.Libraries.Application.Interfaces;
using ACMESchool.Libraries.Application.Models;
using ACMESchool.Libraries.Domain.Entities;
using MediatR;
using System.Net;


namespace ACMESchool.Libraries.Application.UseCases.SchoolOperation.Queries.Course.GetList
{
    public class ListCourseQuery : IRequest<Response<ListCourseResponse>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ListCourseHandler(ICourse repository) : IRequestHandler<ListCourseQuery, Response<ListCourseResponse>>
    {
        public async Task<Response<ListCourseResponse>> Handle(ListCourseQuery request, CancellationToken cancellationToken)
        {

            if (request != null)
            {
                Func<CourseEntity, bool> predicate =
                    x => ((x.StartDate >= request.StartDate && x.EndDate <= request.EndDate));

                var result = await repository.GetCourseAsync(predicate);

                return new Response<ListCourseResponse>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ListCourseResponse
                    {
                        CourseEntities = result
                    },
                };
            }

            return new Response<ListCourseResponse>()
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
