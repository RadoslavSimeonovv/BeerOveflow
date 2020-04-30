using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IReviewService
    {
        Task<ReviewDTO> AddReview(int userId, int beerId, int rating, string rMessage);
    }
}
