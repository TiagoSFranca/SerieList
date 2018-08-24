using System;
using System.Collections.Generic;

namespace SerieList.Application.AppModels.Profile
{
    public class ProfileAppModel
    {
        public int IdProfile { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }
        
        public IEnumerable<ProfilePermissionAppModel> Permissions { get; set; }
    }
}
