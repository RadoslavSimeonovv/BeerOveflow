using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerOverflow.Services
{
    public class CountryService : ICountryService
    {
        private readonly BeerOverflowContext _beerOverflowContext;

        public CountryService(BeerOverflowContext beerOverflowContext)
        {
            this._beerOverflowContext = beerOverflowContext;
        }

        public CountryDTO CreateCountry(CountryDTO countryDTO)
        {
            var country = new Country
            {
                Id = countryDTO.Id,
                Name = countryDTO.Name,

            };

            _beerOverflowContext.Countries.Add(country);
            _beerOverflowContext.SaveChanges();

            return countryDTO;
        }

        public bool DeleteCountry(int id)
        {
            var country = _beerOverflowContext.Countries
               .FirstOrDefault(country => country.Id == id);

            if (id == 0 || country == null)
            {
                throw new ArgumentNullException();
            }

            country.DeletedOn = DateTime.UtcNow;
            _beerOverflowContext.Countries.Update(country);

            return true;
        }

        public IEnumerable<CountryDTO> GetAllCountries()
        {
            var countries = _beerOverflowContext.Countries
               .Where(x => x.DeletedOn == null)
               .Select(x => new CountryDTO
               {
                   Id = x.Id,
                   Name = x.Name,
               });

            return countries;
        }

        public CountryDTO GetCountryById(int id)
        {
            var country = _beerOverflowContext.Countries.
                FirstOrDefault(c => c.Id == id);

            if (country == null)
            {
                throw new ArgumentNullException();
            }

            var countryDTO = new CountryDTO
            {
                Id = country.Id,
                Name = country.Name,
            };

            return countryDTO;
        }

        public CountryDTO UpdateCountry(int id, string newName)
        {
            var country = _beerOverflowContext.Countries
                .FirstOrDefault(country => country.Id == id);

            country.Name = newName;

            var countryDTO = new CountryDTO
            {
                Id = country.Id,
                Name = country.Name,
            };

            _beerOverflowContext.Countries.Update(country);
            _beerOverflowContext.SaveChanges();

            return countryDTO;

        }


    }
}
