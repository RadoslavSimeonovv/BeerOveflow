using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryService
    {
        CountryDTO GetCountryById(int id);
        Task<CountryDTO> GetCountryByIdAsync(int id);
        IEnumerable<CountryDTO> GetAllCountries();
        Task<IEnumerable<CountryDTO>> GetAllCountriesAsync();

        CountryDTO CreateCountry(CountryDTO countryDTO);
        Task<CountryDTO> CreateCountryAsync(CountryDTO countryDTO);
        CountryDTO UpdateCountry(int id, string newName);

        Task<CountryDTO> UpdateCountryAsync(int id, string newName);
        bool DeleteCountry(int id);
        Task<bool> DeleteCountryAsync(int id);

    }
}
