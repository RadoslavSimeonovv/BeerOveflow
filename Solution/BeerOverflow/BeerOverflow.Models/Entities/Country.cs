using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DeletedOn { get; set; }

        public ICollection<Beer> Beers { get; set; }

        public ICollection<Brewery> Breweries { get; set; }

    }
}
