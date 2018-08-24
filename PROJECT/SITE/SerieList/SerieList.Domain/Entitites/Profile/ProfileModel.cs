using SerieList.Domain.Entitites.User;
using System;
using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Profile
{
    public partial class ProfileModel
    {
        public int IdProfile { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<ProfilePermissionModel> Permissions { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
