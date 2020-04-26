using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class BeerViewModel
    {
        public BeerViewModel()
        {

        }
        public BeerViewModel(int id, string beerName, double abv, string description,
            string beerType, int beerTypeId, string brewery, int breweryId)
        {
            this.Id = id;
            this.BeerName = beerName;
            this.AlcByVol = abv;
            this.Description = description;
            this.BeerType = beerType;
            this.BeerTypeId = beerTypeId;
            this.Brewery = brewery;
            this.BreweryId = breweryId;
        }
        public BeerViewModel(int id, string beerName, double abv, string description, string beerType,
            int beerTypeId, string brewery, int breweryId, ICollection<Review> reviews, double avgRating)
        {
            this.Id = id;
            this.BeerName = beerName;
            this.AlcByVol = abv;
            this.Description = description;
            this.BeerType = beerType;
            this.BeerTypeId = beerTypeId;
            this.Brewery = brewery;
            this.BreweryId = breweryId;
            this.Reviews = reviews;
            this.AvgRating = avgRating;
        }
        public BeerViewModel(int id, string beerName, double abv, string description, string beerType,
    int beerTypeId, string brewery, int breweryId, double avgRating)
        {
            this.Id = id;
            this.BeerName = beerName;
            this.AlcByVol = abv;
            this.Description = description;
            this.BeerType = beerType;
            this.BeerTypeId = beerTypeId;
            this.Brewery = brewery;
            this.BreweryId = breweryId;
            this.AvgRating = avgRating;
        }
        public int Id { get; set; }
        public string BeerName { get; set; }
        public double? AlcByVol { get; set; }
        public string Description { get; set; }
        //public DateTime? DateUnlisted { get; set; }
        public String BeerType { get; set; }
        public int BeerTypeId { get; set; }
        public String Brewery { get; set; }
        public int BreweryId { get; set; }

        public double AvgRating { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}