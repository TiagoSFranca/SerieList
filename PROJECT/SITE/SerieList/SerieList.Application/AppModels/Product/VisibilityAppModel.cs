using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerieList.Application.AppModels.Product
{
    public class VisibilityAppModel
    {
        public int IdVisibility { get; set; }
        public string Description { get; set; }
        public bool Excluded { get; set; }
    }
}
