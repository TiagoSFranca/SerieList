using System.Collections.Generic;

namespace SerieList.Application.CommonAppModels
{
    public class PagingResultAppModel<TEntity> : PagingAppModel
        where TEntity : class
    {
        public IEnumerable<TEntity> Items { get; set; }

        public PagingResultAppModel(int actualPage, int itemsPerPage)
            : base(actualPage, itemsPerPage)
        {
        }

        public PagingResultAppModel(PagingAppModel paging)
            : base(paging.ActualPage, paging.ItemsPerPage)
        {

        }
    }
}
