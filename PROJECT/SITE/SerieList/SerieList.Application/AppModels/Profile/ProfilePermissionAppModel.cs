using System;

namespace SerieList.Application.AppModels.Profile
{
    public class ProfilePermissionAppModel
    {
        public int IdProfile { get; set; }
        public int IdPermission { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public PermissionAppModel Permission { get; set; }
    }
}
