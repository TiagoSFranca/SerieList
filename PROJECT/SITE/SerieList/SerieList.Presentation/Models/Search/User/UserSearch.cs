using System.Collections.Generic;

namespace SerieList.Presentation.Models.Search.User
{
    public class UserSearch : PagingSearch
    {
        public List<int> IdList { get; set; }
        public List<int> IdProfileList { get; set; }
        public List<int> IdUserStatusList { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool? Excluded { get; set; }
        public bool? AssociatedExcluded { get; set; }
    }
}