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
    public class BeerTypesService : IBeerTypeService
    {
        private readonly BeerOverflowContext _beerOverflowContext;
        public BeerTypesService(BeerOverflowContext context)
        {
            this._beerOverflowContext = context;
        }
        public BeerTypeDTO GetBeerType(int id)
        {
            var beerType = _beerOverflowContext.BeerTypes
                .FirstOrDefault(t => t.Id == id);

            if (beerType == null)
            {
                throw new ArgumentNullException();
            }
            var beerTypeDTO = new BeerTypeDTO
            {
                Id = beerType.Id,
                Type = beerType.Type,
                Description = beerType.Description,
            };
            return beerTypeDTO;
        }
        public IEnumerable<BeerTypeDTO> GetAllBeerTypes()
        {
            List<BeerTypeDTO> beerTypeDTOs = _beerOverflowContext.BeerTypes
                .Where(bt => bt.DeletedOn == null)
                .Select(bt => new BeerTypeDTO
                {
                    Id = bt.Id,
                    Type = bt.Type,
                    Description = bt.Description,
                }).ToList();
            return beerTypeDTOs;
        }
        public BeerTypeDTO CreateBeerType(BeerTypeDTO beerTypeDTO)
        {
            try
            {
                var beerType = new BeerType
                {
                    Type = beerTypeDTO.Type,
                    Description = beerTypeDTO.Description,
                };
                _beerOverflowContext.BeerTypes.Add(beerType);
                _beerOverflowContext.SaveChanges();

                return beerTypeDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public BeerTypeDTO UpdateBeerType(int id, string type, string description)
        {
            var beerType = _beerOverflowContext.BeerTypes.FirstOrDefault(bt => bt.Id == id);
            if (beerType == null)
            {
                throw new ArgumentNullException();
            }
            beerType.Type = type;
            beerType.Description = description;

            _beerOverflowContext.BeerTypes.Update(beerType);
            _beerOverflowContext.SaveChanges();

            return GetBeerType(id);
        }
        public bool DeleteBeerType(int id)
        {
            var beerType = _beerOverflowContext.BeerTypes.FirstOrDefault(bt => bt.Id == id);
            if (beerType == null)
            {
                throw new ArgumentNullException();
            }
            beerType.DeletedOn = DateTime.UtcNow;
            _beerOverflowContext.SaveChanges();

            return true;
        }
    }
}
