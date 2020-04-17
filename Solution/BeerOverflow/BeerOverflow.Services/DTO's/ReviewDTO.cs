using BeerOverflow.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string RMessage { get; set; }
        public int Rating { get; set; }
        public DateTime? ReviewedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public String Beer { get; set; }
        public int BeerId { get; set; }

        public String User { get; set; }
        public int UserId { get; set; }
    }
}
