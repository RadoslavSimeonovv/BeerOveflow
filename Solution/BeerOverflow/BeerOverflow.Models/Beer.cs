using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string BeerName { get; set; }
        public int TypeId { get; set; }
        public int BreweryId { get; set; }
        public float AlcByVol { get; set; }
        public int OrgnCtryId { get; set; }
        public string Description { get; set; }
        public DateTime DateUnlisted { get; set; }
    }
}
