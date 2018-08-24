using System;

namespace SerieList.Domain.Entitites.Profile
{
    public partial class ProfilePermissionModel
    {
        public int IdProfile { get; set; }
        public int IdPermission { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual ProfileModel Profile { get; set; }
        public virtual PermissionModel Permission { get; set; }
    }
}
