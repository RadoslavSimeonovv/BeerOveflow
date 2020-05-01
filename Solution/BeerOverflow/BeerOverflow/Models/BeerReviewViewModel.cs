using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class BeerReviewViewModel
    {
        public BeerReviewViewModel()
        {

        }
        public BeerReviewViewModel(int id, string beerName, double abv, string description, string beerType,
             int beerTypeId, string brewery, int breweryId, double avgRating)
        {
            this.BeerId = id;
            this.BeerName = beerName;
            this.AlcByVol = abv;
            this.Description = description;
            this.BeerType = beerType;
            this.BeerTypeId = beerTypeId;
            this.Brewery = brewery;
            this.BreweryId = breweryId;
            this.AvgRating = avgRating;
        }
        public int BeerId { get; set; }
        public int UserId { get; set; }
        public string BeerName { get; set; }
        public double? AlcByVol { get; set; }
        public string Description { get; set; }
        public String BeerType { get; set; }
        public int BeerTypeId { get; set; }
        public String Brewery { get; set; }
        public int BreweryId { get; set; }
        public double AvgRating { get; set; }
        public int Rating { get; set; }
        public string RMessage { get; set; }
    }
}

