using BeerOverflow.Data;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var beerTypeDTO = new BeerTypeDTO(beerType.Id, beerType.Type, beerType.Description);
            return beerTypeDTO;
        }

        public async Task<BeerTypeDTO> GetBeerTypeAsync(int id)
        {
            var beerType = await _beerOverflowContext.BeerTypes
                .FirstOrDefaultAsync(t => t.Id == id);

            if (beerType == null)
            {
                throw new ArgumentNullException();
            }
            var beerTypeDTO = new BeerTypeDTO(beerType.Id, beerType.Type, beerType.Description);
            return beerTypeDTO;
        }


        public IEnumerable<BeerTypeDTO> GetAllBeerTypes()
        {
            List<BeerTypeDTO> beerTypeDTOs = _beerOverflowContext.BeerTypes
                .Where(bt => bt.DeletedOn == null)
                .Select(bt => new BeerTypeDTO(bt.Id, bt.Type, bt.Description))
                .ToList();

            return beerTypeDTOs;
        }

        public async Task<IEnumerable<BeerTypeDTO>> GetAllBeerTypesAsync()
        {
            List<BeerTypeDTO> beerTypeDTOs = await _beerOverflowContext.BeerTypes
                .Where(bt => bt.DeletedOn == null)
                .Select(bt => new BeerTypeDTO(bt.Id, bt.Type, bt.Description))
                .ToListAsync();

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

        public async Task<BeerTypeDTO> CreateBeerTypeAsync(BeerTypeDTO beerTypeDTO)
        {
            try
            {
                var beerType = new BeerType
                {
                    Type = beerTypeDTO.Type,
                    Description = beerTypeDTO.Description,
                };
                await _beerOverflowContext.BeerTypes.AddAsync(beerType);
                await _beerOverflowContext.SaveChangesAsync();

                return beerTypeDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BeerTypeDTO UpdateBeerType(int id, string type, string description)
        {
            var beerType = _beerOverflowContext.BeerTypes
                .FirstOrDefault(bt => bt.Id == id);
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

        public async Task<BeerTypeDTO> UpdateBeerTypeAsync(int id, string type, string description)
        {
            var beerType = await _beerOverflowContext.BeerTypes
                .FirstOrDefaultAsync(bt => bt.Id == id);
            if (beerType == null)
            {
                throw new ArgumentNullException();
            }
            beerType.Type = type;
            beerType.Description = description;

            await _beerOverflowContext.SaveChangesAsync();

            return GetBeerType(id);
        }

        public bool DeleteBeerType(int id)
        {
            var beerType = _beerOverflowContext.BeerTypes
                .FirstOrDefault(bt => bt.Id == id);
            if (beerType == null)
            {
                throw new ArgumentNullException();
            }
            beerType.DeletedOn = DateTime.UtcNow;
            _beerOverflowContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteBeerTypeAsync(int id)
        {
            var beerType = await _beerOverflowContext.BeerTypes
                .FirstOrDefaultAsync(bt => bt.Id == id);
            if (beerType == null)
            {
                throw new ArgumentNullException();
            }
            beerType.DeletedOn = DateTime.UtcNow;
            await _beerOverflowContext.SaveChangesAsync();

            return true;
        }
    }
}
