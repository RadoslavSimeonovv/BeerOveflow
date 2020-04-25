using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class BeerTypeViewModel
    {
        public BeerTypeViewModel()
        {

        }
        public BeerTypeViewModel(int id, string type, string description)
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
