using Global.UserAudit.Application.Contracts.Notifications;
using Global.UserAudit.Application.Contracts.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using AutoFixture;
using Global.UserAudit.Application.Entities;
using Global.UserAudit.Application.Models.Notifications;
using Global.UserAudit.Application.Features.Users.Commands.UserChange;

namespace Global.UserAudit.UnitTest.Application.Features.Tasks.Commands
{
    public class UserChangeUnitTest
    {
        readonly Mock<IUserRepository> _userRepository;
        readonly Mock<ILogger<UserChangeHandler>> _logger;
        readonly Mock<INotificationsHandler> _notificationsHandler;
        readonly Fixture _fixture;
        readonly UserChangeHandler _handler;

        public UserChangeUnitTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _logger = new Mock<ILogger<UserChangeHandler>>();
            _notificationsHandler = new Mock<INotificationsHandler>();
            _fixture = new Fixture();
            _handler = new UserChangeHandler(_userRepository.Object, _logger.Object, _notificationsHandler.Object);
        }

        [Fact]
        public async Task Task_Should_Be_Created_Successfully_When_All_Information_Has_Been_Submitted()
        {
            var taskCommand = _fixture.Create<UserChangeCommand>();

            var response = await _handler.Handle(taskCommand, CancellationToken.None);

            Assert.False(Guid.Empty == response);
            _userRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task Task_Should_Not_Be_Created_When_An_Exception_Was_Thrown()
        {
            var taskCommand = new UserChangeCommand(string.Empty, DateTime.Now, EProfile.Administrator, Guid.Empty, true, EChangeType.Insert);
            _userRepository.Setup(x => x.AddAsync(It.IsAny<User>())).Throws(new Exception());
            _notificationsHandler
                .Setup(x => x.AddNotification(It.IsAny<string>(), It.IsAny<ENotificationType>(), It.IsAny<object>()))
                    .Returns(_notificationsHandler.Object);
            _notificationsHandler.Setup(x => x.ReturnDefault<Guid>()).Returns(Guid.Empty);

            var response = await _handler.Handle(taskCommand, CancellationToken.None);

            Assert.True(Guid.Empty == response);
            _userRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}