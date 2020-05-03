using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class BeerReviewEditViewModel
    {
        public BeerReviewEditViewModel()
        {

        }

        public BeerReviewEditViewModel(int reviewId, string rMessage, string userName, string beerName, double abv, string description,
                        string beerType, string brewery, double avgRating,
                        DateTime? reviewedOn, DateTime? deletedOn)
        {
            this.Id = reviewId;
            this.RMessage = rMessage;
            this.UserName = userName;
            this.BeerName = beerName;
            this.AlcByVol = abv;
            this.Description = description;
            this.BeerType = beerType;
            this.Brewery = brewery;
            this.AvgRating = avgRating;
            this.ReviewedOn = reviewedOn;
            this.DeletedOn = deletedOn;
        }
        public int Id { get; set; }
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public double? AlcByVol { get; set; }
        public string Description { get; set; }
        public String BeerType { get; set; }
        public int BeerTypeId { get; set; }
        public String Brewery { get; set; }
        public int BreweryId { get; set; }
        public double AvgRating { get; set; }
        public int Rating { get; set; }
        public string RMessage { get; set; }
        public DateTime? ReviewedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}

