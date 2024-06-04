using ACMESchool.Libraries.Application.Interfaces;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Student;
using AutoFixture;
using FluentAssertions;
using Moq;
using System.Net;

namespace TestSchoolACME
{
    public class UnitTest1
    {
        private readonly Mock<IStudent> _command;
        private readonly CreateStudentHandler _handler;
        private readonly Fixture _fixture;
        private readonly CancellationToken _cancellationToken;
        public UnitTest1()
        {
            _command = new Mock<IStudent>();
            _handler = new CreateStudentHandler(_command.Object);
            _fixture = new Fixture();
            _cancellationToken = CancellationToken.None;
        }

        [Fact]
        public async void Handle_CreateStudent_AgeMinors()
        {
            // Arrange
            var request = new CreateStudentCommand
            {
                Age = 16,
                Name = "Test",
            };
            // Act
            var response = await _handler.Handle(request, _cancellationToken);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

        [Fact]
        public async void Handle_CreateStudent_Success()
        {
            // Arrange
            var request = new CreateStudentCommand
            {
                Age = 18,
                Name = "Test",
            };
            // Act
            var response = await _handler.Handle(request, _cancellationToken);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

    }
}