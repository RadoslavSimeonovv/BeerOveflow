using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class CountryDTO
    {
        public CountryDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
