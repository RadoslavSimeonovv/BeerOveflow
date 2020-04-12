using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface ICountryService
    {
        CountryDTO GetCountryById(int id);
        IEnumerable<CountryDTO> GetAllCountries();
        CountryDTO CreateCountry(CountryDTO countryDTO);
        CountryDTO UpdateCountry(int id, string newName);
        bool DeleteCountry(int id);

    }
}
