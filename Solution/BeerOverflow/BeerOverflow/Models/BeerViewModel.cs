using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            int beerTypeId, string brewery, int breweryId, ICollection<Review> reviews, double avgRating, DateTime? dateUnlisted)
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
            this.DateUnlisted = dateUnlisted;
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

        public BeerViewModel(int id, string beerName, double abv, string description, string beerType,
int beerTypeId, string brewery, int breweryId, DateTime? dateUnlisted, double avgRating)
        {
            this.Id = id;
            this.BeerName = beerName;
            this.AlcByVol = abv;
            this.Description = description;
            this.BeerType = beerType;
            this.BeerTypeId = beerTypeId;
            this.Brewery = brewery;
            this.BreweryId = breweryId;
            this.DateUnlisted = dateUnlisted;
            this.AvgRating = avgRating;
        }
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Beer name")]
        public string BeerName { get; set; }

        [Required]
        [DisplayName("Alcohol by volume")]
        public double? AlcByVol { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Beer Description")]
        public string Description { get; set; }
        //public DateTime? DateUnlisted { get; set; }


        [DisplayName("Beer Style")]
        public String BeerType { get; set; }

        [Required]
        public int BeerTypeId { get; set; }

        [DisplayName("Brewery")]
        public String Brewery { get; set; }

        [Required]
        public int BreweryId { get; set; }

        [DisplayName("Unlisted date")]
        public DateTime? DateUnlisted { get; set; }

        [DisplayName("Average rating")]
        public double AvgRating { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}