using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class BreweryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public String Country { get; set; }
        public int CountryId { get; set; }


    }
}
