using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Entities
{
    public class Beer
    {
        public int Id { get; set; }
        public string BeerName { get; set; }
        public double AlcByVol { get; set; }
        public string Description { get; set; }
        public DateTime? DateUnlisted { get; set; }

        public BeerType BeerType { get; set; }
        public int BeerTypeId { get; set; }

        public Brewery Brewery { get; set; }
        public int BreweryId { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
