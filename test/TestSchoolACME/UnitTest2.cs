using ACMESchool.Libraries.Application.Interfaces;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.CourseStudent;
using ACMESchool.Libraries.Application.UseCases.SchoolOperation.Commnads.Student;
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
    public class UnitTest2
    {
        private readonly Mock<ICourseStudentRelation> _command;
        private readonly Mock<IPaymentGateway> _paymentGateway;
        private readonly ContractCourseHandler _handler;
        private readonly Fixture _fixture;
        private readonly CancellationToken _cancellationToken;
        public UnitTest2()
        {
            _command = new Mock<ICourseStudentRelation>();
            _paymentGateway = new Mock<IPaymentGateway>();
            _handler = new ContractCourseHandler(_command.Object, _paymentGateway.Object);
            _fixture = new Fixture();
            _cancellationToken = CancellationToken.None;
        }

        [Fact]
        public async void Handle_ContractCourse_Success()
        {
            // Arrange
            var request = new ContractCourseCommnad
            {
                CourseId = 12,
                RegistrationPayment = 500,
                StudentId = 1,
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
            ContractCourseCommnad request = null;
            // Act
            var response = await _handler.Handle(request, _cancellationToken);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

    }
}
