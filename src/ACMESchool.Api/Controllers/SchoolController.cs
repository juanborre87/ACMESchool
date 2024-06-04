using ACMESchool.Libraries.Application.Models;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Course;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.CourseStudent;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Student;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Queries.Course.GetList;
using Microsoft.AspNetCore.Mvc;

namespace ACMESchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : BaseApiController
    {
        [Route("Student")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateStudentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateStudentCommand request)
        {
            return Result(await Mediator.Send(request));
        }

        [Route("Course")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateCourseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(CreateCourseCommand request)
        {
            return Result(await Mediator.Send(request));
        }

        [Route("ContractCourse")]
        [HttpPost]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ContractCourseCommnad request)
        {
            return Result(await Mediator.Send(request));
        }

        [Route("CourseList")]
        [HttpPost]
        [ProducesResponseType(typeof(ListCourseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Notify>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create(ListCourseQuery request)
        {
            return Result(await Mediator.Send(request));
        }
    }
}
