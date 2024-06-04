using ACMESchool.Libraries.Application.Interfaces;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Course;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.CourseStudent;
using AutoFixture;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestSchoolACME
{
    public class UnitTest3
    {
        private readonly Mock<ICourse> _command;
        private readonly CreateCourseHandler _handler;
        private readonly Fixture _fixture;
        private readonly CancellationToken _cancellationToken;
        public UnitTest3()
        {
            _command = new Mock<ICourse>();
            _handler = new CreateCourseHandler(_command.Object);
            _fixture = new Fixture();
            _cancellationToken = CancellationToken.None;
        }

        [Fact]
        public async void Handle_ContractCourse_Success()
        {
            // Arrange
            var request = new CreateCourseCommand
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now.AddDays(-1),
                RegistrationFee = 500,
                Name = "Test",
            };
            // Act
            var response = await _handler.Handle(request, _cancellationToken);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async void Handle_CreateStudent_NoSuccess()
        {
            // Arrange
            CreateCourseCommand request = null;
            // Act
            var response = await _handler.Handle(request, _cancellationToken);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

    }
}
