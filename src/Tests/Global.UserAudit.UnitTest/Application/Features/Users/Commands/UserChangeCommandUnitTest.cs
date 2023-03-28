using AutoFixture;
using Global.UserAudit.Application.Entities;
using Global.UserAudit.Application.Features.Users.Commands.UserChange;

namespace Global.UserAudit.UnitTest.Application.Features.Users.Commands
{
    public class UserChangeCommandUnitTest
    {
        readonly Fixture _fixture;

        public UserChangeCommandUnitTest()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void Command_Should_Be_Valid()
        {
            var command = _fixture.Create<UserChangeCommand>();

            var result = command.Validate();

            Assert.True(result);
        }

        [Fact]
        public void Command_Should_Be_Invalid()
        {
            var command = new UserChangeCommand(string.Empty, DateTime.Now, EProfile.Administrator, Guid.Empty, true, EChangeType.Update);

            var result = command.Validate();

            Assert.False(result);
        }
    }
}
