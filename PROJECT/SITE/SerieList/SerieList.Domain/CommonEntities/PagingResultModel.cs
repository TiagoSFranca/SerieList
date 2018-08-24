using System.Collections.Generic;

namespace SerieList.Domain.CommonEntities
{
    public class PagingResultModel<TEntity> : PagingModel
        where TEntity : class
    {
        public IEnumerable<TEntity> Items { get; set; }

        public PagingResultModel(int actualPage, int itemsPerPage)
            : base(actualPage, itemsPerPage)
        {
        }

        public PagingResultModel(PagingModel paging)
            : base(paging.ActualPage, paging.ItemsPerPage)
        {

        }
    }
}
