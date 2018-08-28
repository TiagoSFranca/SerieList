using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Interfaces;
using SerieList.Domain.Seed.Profile;
using SerieList.Domain.Seed.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Profile;
using SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.User;
using SerieList.Infra.Data.CrossCutting.Exceptions.ServiceException;
using System.Linq;

namespace SerieList.Domain.Entitites.User
{
    partial class UserModel : IExcluded
    {
        public virtual void IsGranted(bool authentication = false)
        {
            UserServiceMessage userMessage = new UserServiceMessage();
            ProfileServiceMessage profileMessage = new ProfileServiceMessage();
            UserStatusServiceMessage userStatusMessage = new UserStatusServiceMessage();
            if (Excluded)
                throw new ServiceException(userMessage.Excluded);
            if (Profile.Excluded)
                throw new ServiceException(profileMessage.Excluded);
            if (UserStatus.Excluded)
                throw new ServiceException(userStatusMessage.Excluded);
            if (IdUserStatus == UserStatusSeed.Blocked.IdUserStatus || IdUserStatus == UserStatusSeed.Inactive.IdUserStatus || IdUserStatus == UserStatusSeed.Suspended.IdUserStatus)
                throw new ServiceException(userStatusMessage.HasStatus(UserStatus.Description));
            if (!UserInfo.EmailConfirmed && !authentication)
                throw new ServiceException(userMessage.MailNotConfirmed);
        }

        public virtual void HasPermission(PermissionModel permission)
        {
            PermissionServiceMessage permissionMessage = new PermissionServiceMessage();
            if (permission == null)
                throw new ServiceException(permissionMessage.NotFound);

            UserServiceMessage userMessage = new UserServiceMessage();
            if (!Profile.Permissions.Any(e => (e.IdPermission == permission.IdPermission && !permission.Excluded) || e.IdPermission == PermissionSeed.Admin.IdPermission))
                throw new ServiceException(userMessage.Unauthorized);
        }

        public virtual void ValidateExcluded()
        {
            UserServiceMessage usm = new UserServiceMessage();
            if (Excluded)
                throw new ServiceException(usm.Excluded);
        }
    }
}
