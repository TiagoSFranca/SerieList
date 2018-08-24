namespace SerieList.Domain.Entitites
{
    public class ConfigurationModel
    {
        public int IdConfiguration { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Excluded { get; set; }
    }
}
