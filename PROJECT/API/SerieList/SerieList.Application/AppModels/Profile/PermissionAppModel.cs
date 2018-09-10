namespace SerieList.Application.AppModels.Profile
{
    public class PermissionAppModel
    {
        public int IdPermission { get; set; }
        public int IdPermissionType { get; set; }
        public int IdPermissionGroup { get; set; }
        public bool Excluded { get; set; }

        public PermissionTypeAppModel PermissionType { get; set; }
        public PermissionGroupAppModel PermissionGroup { get; set; }
    }
}
