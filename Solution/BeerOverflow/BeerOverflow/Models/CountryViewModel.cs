using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {

        }
        public CountryViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
