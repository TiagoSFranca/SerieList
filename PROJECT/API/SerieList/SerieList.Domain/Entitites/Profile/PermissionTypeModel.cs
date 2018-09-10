using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Profile
{
    public partial class PermissionTypeModel
    {
        public int IdPermissionType { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }

        public virtual ICollection<PermissionModel> Permissions { get; set; }
    }
}
