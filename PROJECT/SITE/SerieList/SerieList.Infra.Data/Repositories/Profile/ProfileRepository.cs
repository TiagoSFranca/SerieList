using SerieList.Domain.Entitites.Profile;
using SerieList.Domain.Interfaces.Repositories.Profile;
using System.Data.Entity;
using System.Linq;

namespace SerieList.Infra.Data.Repositories.Profile
{
    public class ProfileRepository : RepositoryBase<ProfileModel>, IProfileRepository
    {
        public void Add(ProfileModel obj)
        {
            _context.Profile.Add(obj);
            _context.ProfilePermission.AddRange(obj.Permissions);
            _context.SaveChanges();
        }

        public void Update(ProfileModel obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            ManageCategories(obj);
            _context.SaveChanges();
        }

        private void ManageCategories(ProfileModel obj)
        {
            DeleteAllPermissions(obj);
            AddOrUpdatePermissions(obj);
        }

        private void AddOrUpdatePermissions(ProfileModel obj)
        {
            foreach (var item in obj.Permissions)
            {
                var permissionAny = _context.ProfilePermission.Any(e => e.IdPermission == item.IdPermission && e.IdProfile == obj.IdProfile);
                if (permissionAny)
                    _context.Entry(item).State = EntityState.Modified;
                else
                    _context.ProfilePermission.Add(item);
            }
        }

        private void DeleteAllPermissions(ProfileModel obj)
        {
            var permissionIdList = obj.Permissions.Select(e => e.IdPermission).ToList();
            var permissions = _context.ProfilePermission.Where(
                e => e.IdProfile == obj.IdProfile &&
                !permissionIdList.Contains(e.IdPermission));
            _context.ProfilePermission.RemoveRange(permissions);
        }
    }
}
