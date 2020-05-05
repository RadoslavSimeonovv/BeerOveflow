using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeerOverflow.Services.Contracts
{
    public interface IReviewService
    {
        Task<ReviewDTO> AddReviewAsync(string userName, string beerName, int rating, string rMessage);
        Task<ReviewDTO> AddReview(int userId, int beerId, int rating, string rMessage);

        Task<ReviewDTO> GetReviewAsync(int ReviewId);

        Task<bool> ModifyReviewAsync(int reviewId, string rMessage, bool isDeleted);
    }
}
