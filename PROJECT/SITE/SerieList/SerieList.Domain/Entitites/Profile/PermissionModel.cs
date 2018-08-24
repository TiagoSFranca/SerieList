using SerieList.Domain.Interfaces;
using System.Collections.Generic;

namespace SerieList.Domain.Entitites.Profile
{
    public partial class PermissionModel : IAssociation<PermissionModel>
    {
        public int IdPermission { get; set; }
        public int IdPermissionType { get; set; }
        public int IdPermissionGroup { get; set; }
        public bool Excluded { get; set; }

        public virtual PermissionTypeModel PermissionType { get; set; }
        public virtual PermissionGroupModel PermissionGroup { get; set; }

        public virtual ICollection<ProfilePermissionModel> Profiles { get; set; }


        public virtual PermissionModel AssociationExcluded(bool excluded)
        {
            if (PermissionType.Excluded == excluded && PermissionGroup.Excluded == excluded)
                return this;
            return null;
        }
    }
}
