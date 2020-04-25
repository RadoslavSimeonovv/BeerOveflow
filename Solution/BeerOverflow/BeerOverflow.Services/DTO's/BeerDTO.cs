using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class BeerDTO
    {
        //public BeerDTO()
        //{
        //    this.Reviews = new ICollection<Review>();
        //}
        public BeerDTO(string beerName, int beerTypeId, int breweryId, double abv, string description)
        {
            this.BeerName = beerName;
            this.BeerTypeId = beerTypeId;
            this.BreweryId = breweryId;
            this.AlcByVol = abv;
            this.Description = description;
        }
        public BeerDTO(int id, string beerName, int beerTypeId, string beerType, int breweryId, string breweryName, double abv, string description)
        {
            this.Id = id;
            this.BeerName = beerName;
            this.BeerTypeId = beerTypeId;
            this.BeerType = beerType;
            this.BreweryId = breweryId;
            this.Brewery = breweryName;
            this.AlcByVol = abv;
            this.Description = description;
        }

        public BeerDTO(int id, string beerName, int beerTypeId, string beerType, int breweryId, string breweryName, double abv, string description,ICollection<Review> reviews)
        {
            this.Id = id;
            this.BeerName = beerName;
            this.BeerTypeId = beerTypeId;
            this.BeerType = beerType;
            this.BreweryId = breweryId;
            this.Brewery = breweryName;
            this.AlcByVol = abv;
            this.Description = description;
            this.Reviews = reviews;
        }
        public int Id { get; set; }
        public string BeerName { get; set; }
        public double AlcByVol { get; set; }
        public string Description { get; set; }
        public DateTime? DateUnlisted { get; set; }
        public String BeerType { get; set; }
        public int BeerTypeId { get; set; }
        public String Brewery { get; set; }
        public int BreweryId { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
