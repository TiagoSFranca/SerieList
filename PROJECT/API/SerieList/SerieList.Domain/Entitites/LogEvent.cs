using System;

namespace SerieList.Domain.Entitites
{
    public class LogEvent
    {
        public int IdEvent { get; set; }
        public string Exception { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Excluded { get; set; }
    }
}
