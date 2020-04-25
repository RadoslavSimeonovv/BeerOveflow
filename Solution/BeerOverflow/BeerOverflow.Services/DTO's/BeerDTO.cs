using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class BeerDTO
    {
        public int Id { get; set; }
        public string BeerName { get; set; }
        public double AlcByVol { get; set; }
        public string Description { get; set; }
        public DateTime? DateUnlisted { get; set; }

        public String BeerType { get; set; }
        public int BeerTypeId { get; set; }

        public String Brewery { get; set; }
        public int BreweryId { get; set; }
    }
}
