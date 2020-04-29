using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<CountryDTO> CreateCountryAsync(CountryDTO countryDTO)
        {
            var country = new Country
            {
                Id = countryDTO.Id,
                Name = countryDTO.Name,
            };

            await _beerOverflowContext.Countries.AddAsync(country);
            await _beerOverflowContext.SaveChangesAsync();

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
            _beerOverflowContext.SaveChanges();

            return true;
        }


        public async Task<bool> DeleteCountryAsync(int id)
        {
            var country = await _beerOverflowContext.Countries
               .FirstOrDefaultAsync(country => country.Id == id);

            if (id == 0 || country == null)
            {
                throw new ArgumentNullException();
            }

            country.DeletedOn = DateTime.UtcNow;
            await _beerOverflowContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<CountryDTO> GetAllCountries()
        {
            var countries = _beerOverflowContext.Countries
               .Where(x => x.DeletedOn == null)
               .Select(x => new CountryDTO(x.Id, x.Name));


            return countries;
        }

        public async Task<IEnumerable<CountryDTO>> GetAllCountriesAsync()
        {
            var countries = await _beerOverflowContext.Countries
               .Where(x => x.DeletedOn == null)
               .Select(x => new CountryDTO(x.Id, x.Name))
               .ToListAsync();
     
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

            var countryDTO = new CountryDTO(country.Id, country.Name);

            return countryDTO;
        }


        public async Task<CountryDTO> GetCountryByIdAsync(int id)
        {
            var country = await _beerOverflowContext.Countries.
                FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                throw new ArgumentNullException();
            }

            var countryDTO = new CountryDTO(country.Id, country.Name);

            return countryDTO;
        }


        public CountryDTO UpdateCountry(int id, string newName)
        {
            var country = _beerOverflowContext.Countries
                .FirstOrDefault(country => country.Id == id);

            country.Name = newName;

            var countryDTO = new CountryDTO(country.Id, country.Name);


            _beerOverflowContext.Countries.Update(country);
            _beerOverflowContext.SaveChanges();

            return countryDTO;

        }

        public async Task<CountryDTO> UpdateCountryAsync(int id, string newName)
        {
            var country = await _beerOverflowContext.Countries
                .FirstOrDefaultAsync(country => country.Id == id);

            country.Name = newName;

            var countryDTO = new CountryDTO(country.Id, country.Name);

           await  _beerOverflowContext.SaveChangesAsync();

            return countryDTO;

        }
    }
}
