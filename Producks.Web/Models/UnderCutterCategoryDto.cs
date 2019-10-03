using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producks.Web.Models
{
    public class UnderCutterCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int AvailableProductCount { get; set; }
    }
}
