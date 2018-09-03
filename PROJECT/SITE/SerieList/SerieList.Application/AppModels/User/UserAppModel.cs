using SerieList.Application.AppModels.Profile;
using System;

namespace SerieList.Application.AppModels.User
{
    public class UserAppModel
    {
        public int IdUser { get; set; }
        public int IdProfile { get; set; }
        public int IdUserStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Excluded { get; set; }

        public virtual UserInfoAppModel UserInfo { get; set; }
        public virtual ProfileAppModel Profile { get; set; }
        public virtual UserStatusAppModel UserStatus { get; set; }
    }

    public class UserSimplifiedAppModel
    {
        public int IdUser { get; set; }

        public virtual UserInfoSimplifiedAppModel UserInfo { get; set; }
    }
}
