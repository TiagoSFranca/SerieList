﻿using SerieList.Domain.Entitites.Profile;
using System.Collections.Generic;

namespace SerieList.Domain.Seed.Profile
{
    public class PermissionTypeSeed
    {
        //public static PermissionTypeModel List { get { return new PermissionTypeModel() { IdPermissionType = 1, Description = "Listar", Excluded = false }; } }
        //public static PermissionTypeModel Get { get { return new PermissionTypeModel() { IdPermissionType = 2, Description = "Obter", Excluded = false }; } }
        public static PermissionTypeModel Add { get { return new PermissionTypeModel() { IdPermissionType = 3, Description = "Salvar", Excluded = false }; } }
        public static PermissionTypeModel Update { get { return new PermissionTypeModel() { IdPermissionType = 4, Description = "Atualizar", Excluded = false }; } }
        public static PermissionTypeModel Remove { get { return new PermissionTypeModel() { IdPermissionType = 5, Description = "Excluir", Excluded = false }; } }
        public static PermissionTypeModel Admin { get { return new PermissionTypeModel() { IdPermissionType = 6, Description = "Admin", Excluded = false }; } }

        public static List<PermissionTypeModel> Seeds
        {
            get
            {
                return new List<PermissionTypeModel>()
                {
                    //List,
                    //Get,
                    Add,
                    Update,
                    Remove,
                    Admin
                };
            }
        }
    }
}
