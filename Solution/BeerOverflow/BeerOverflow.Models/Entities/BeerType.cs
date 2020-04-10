using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class BeerType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public ICollection<Beer> Beers { get; set; }
    }
}
