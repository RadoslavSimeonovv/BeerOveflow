using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class BreweryDTO
    {
        public BreweryDTO(int id, string name, string descrip, int countryId)
        {
            this.Id = id;
            this.Name = name;
            this.Description = descrip;
            this.CountryId = countryId;
        }

        public BreweryDTO(int id, string name, string descrip, int countryId, string countryName)
        {
            this.Id = id;
            this.Name = name;
            this.Description = descrip;
            this.CountryId = countryId;
            this.Country = countryName;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public String Country { get; set; }
        public int CountryId { get; set; }


    }
}
