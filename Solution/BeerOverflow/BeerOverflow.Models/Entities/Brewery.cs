using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class Brewery
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public ICollection<Beer> Beers { get; set; }

    }
}
