namespace SerieList.Application.CommonAppModels
{
    public class PagingAppModel
    {
        public int ActualPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PagingAppModel(int actualPage, int itemsPerPage)
        {
            ActualPage = actualPage;
            ItemsPerPage = itemsPerPage;
        }
    }
}
