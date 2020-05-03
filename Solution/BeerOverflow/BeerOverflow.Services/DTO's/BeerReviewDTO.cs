using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class BeerReviewDTO
    {
        public BeerReviewDTO()
        {

        }
        public BeerReviewDTO(int id, string beerName, double abv, string description, string beerType,
             int beerTypeId, string brewery, int breweryId, double avgRating)
        {
            this.BeerId = id;
            this.BeerName = beerName;
            this.AlcByVol = abv;
            this.Description = description;
            this.BeerType = beerType;
            //this.BeerTypeId = beerTypeId;
            this.Brewery = brewery;
            //this.BreweryId = breweryId;
            this.AvgRating = avgRating;
        }

        public BeerReviewDTO(int? reviewId, int beerId, string beerName, string userName, double abv, string description,
                                string beerType, int beerTypeId, string brewery, int breweryId, double avgRating,
                                DateTime? reviewedOn, DateTime? deletedOn)
        {
            this.Id = reviewId;
            this.BeerId = beerId;
            this.BeerName = beerName;
            this.UserName = userName;
            this.AlcByVol = abv;
            this.Description = description;
            this.BeerType = beerType;
            //this.BeerTypeId = beerTypeId;
            this.Brewery = brewery;
            //this.BreweryId = breweryId;
            this.AvgRating = avgRating;
            this.ReviewedOn = reviewedOn;
            this.DeletedOn = deletedOn;
        }
        public int? Id { get; set; }
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public double? AlcByVol { get; set; }
        public string Description { get; set; }
        public string BeerType { get; set; }
        //public int BeerTypeId { get; set; }
        public string Brewery { get; set; }
        //public int BreweryId { get; set; }
        public double AvgRating { get; set; }
        public int Rating { get; set; }
        public string RMessage { get; set; }
        public DateTime? ReviewedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
