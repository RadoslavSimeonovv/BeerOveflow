using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class UserBeersDTO
    {
        public UserBeersDTO(string user, int userId, string beer, int beerId)
        {
            this.User = user;
            this.UserId = userId;
            this.Beer = beer;
            this.BeerId = beerId;
        }

        public UserBeersDTO(string user, int userId, string beer, int beerId, DateTime? drankOn)
        {
            this.User = user;
            this.UserId = userId;
            this.Beer = beer;
            this.BeerId = beerId;
            this.DrankOn = drankOn;
        }

        public String User { get; set; }
        public int UserId { get; set; }

        public String Beer { get; set; }
        public int BeerId { get; set; }

        public DateTime? DrankOn { get; set; }
    }
}
