namespace SerieList.Infra.Data.CrossCutting.Exceptions.Messges.ServiceMessages.Season
{
    public class SeasonServiceMessage : GenericMessageService
    {
        public SeasonServiceMessage()
        {
            this.Name = "Temporada";
        }

        public string NotInProduct(int idProduct)
        {
            return string.Format("Temporada não cadastrada para o produto de id {[0}]", idProduct);
        }
    }
}
