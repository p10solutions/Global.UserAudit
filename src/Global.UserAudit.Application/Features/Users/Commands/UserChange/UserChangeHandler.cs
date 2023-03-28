using Global.UserAudit.Application.Contracts.Notifications;
using Global.UserAudit.Application.Contracts.Repositories;
using Global.UserAudit.Application.Models.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Global.UserAudit.Application.Features.Users.Commands.UserChange
{
    public class UserChangeHandler : IRequestHandler<UserChangeCommand, Guid>
    {
        readonly IUserRepository _userRepository;
        readonly ILogger<UserChangeHandler> _logger;
        readonly INotificationsHandler _notificationsHandler;

        public UserChangeHandler(IUserRepository userRepository, ILogger<UserChangeHandler> logger,
            INotificationsHandler notificationsHandler)
        {
            _userRepository = userRepository;
            _logger = logger;
            _notificationsHandler = notificationsHandler;
        }

        public async Task<Guid> Handle(UserChangeCommand request, CancellationToken cancellationToken)
        {
            var user = UserChangeCommandMapper.MapTo(request);

            try
            {
                await _userRepository.AddAsync(user);

                return user.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred when trying to create the user: {exception}", ex.Message);
                return _notificationsHandler
                        .AddNotification("An error occurred when trying to create the user", ENotificationType.InternalError)
                        .ReturnDefault<Guid>();
            }
        }
    }
}
