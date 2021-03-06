﻿using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class ReviewDTO
    {
        public ReviewDTO(string rMessage, int rating,
           int userId, int beerId, DateTime? reviewedOn)
        {
            this.RMessage = rMessage;
            this.Rating = rating;
            this.UserId = userId;
            this.BeerId = beerId;
            this.ReviewedOn = reviewedOn;
        }


        public ReviewDTO(int id, string rMessage, int rating, string user,
            int userId, string beer, int beerId, DateTime? reviewedOn, DateTime? deletedOn)
        {
            this.Id = id;
            this.RMessage = rMessage;
            this.Rating = rating;
            this.User = user;
            this.UserId = userId;
            this.Beer = beer;
            this.BeerId = beerId;
            this.ReviewedOn = reviewedOn;
            this.DeletedOn = deletedOn;
        }

        public ReviewDTO(int id, string rMessage, int rating, string user,
    int userId, string beer, int beerId, DateTime? reviewedOn)
        {
            this.Id = id;
            this.RMessage = rMessage;
            this.Rating = rating;
            this.User = user;
            this.UserId = userId;
            this.Beer = beer;
            this.BeerId = beerId;
            this.ReviewedOn = reviewedOn;
        }

        public int Id { get; set; }
        public string RMessage { get; set; }
        public int Rating { get; set; }
        public DateTime? ReviewedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public string Beer { get; set; }
        public int BeerId { get; set; }

        public string User { get; set; }
        public int UserId { get; set; }
    }
}
