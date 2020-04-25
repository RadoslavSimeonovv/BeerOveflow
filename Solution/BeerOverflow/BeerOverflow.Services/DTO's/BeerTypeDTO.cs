using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.DTO_s
{
    public class BeerTypeDTO
    {
        public BeerTypeDTO(string type, string description)
        {
            this.Type = type;
            this.Description = description;
        }
        public BeerTypeDTO(int id, string type, string description)
        {
            this.Id = id;
            this.Type = type;
            this.Description = description;
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
