using System.Collections.Generic;

namespace SerieList.Domain.CommonEntities
{
    public class PagingModel
    {
        public int ActualPage { get; private set; }
        public int ItemsPerPage { get; private set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get
            {
                return (TotalItems / ItemsPerPage) + (TotalItems % ItemsPerPage != 0 ? 1 : 0);
            }
            private set { }
        }

        public PagingModel(int actualPage, int itemsPerPage)
        {
            ActualPage = actualPage > 0 ? actualPage : 1;
            ItemsPerPage = itemsPerPage;
        }
    }
}
