using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IReviewService
    {
        ReviewDTO AddReview(int userName, int beerName, int rating, string rMessage);
    }
}
