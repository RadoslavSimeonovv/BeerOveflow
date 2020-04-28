using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class ReviewViewModel
    {
        public ReviewViewModel()
        {

        }
        public ReviewViewModel( string rMessage, int rating, string user,
         Guid userId, string beer, int beerId, DateTime? reviewedOn)
        {
            this.RMessage = rMessage;
            this.Rating = rating;
            this.UserName = user;
            this.UserId = userId;
            this.BeerName = beer;
            this.BeerId = beerId;
            this.ReviewedOn = reviewedOn;
        }
        public string RMessage { get; set; }
        public int Rating { get; set; }
        public DateTime? ReviewedOn { get; set; }
        //public DateTime? DeletedOn { get; set; }

        public String BeerName { get; set; }
        public int BeerId { get; set; }

        public String UserName { get; set; }
        public Guid UserId { get; set; }
    }
}
