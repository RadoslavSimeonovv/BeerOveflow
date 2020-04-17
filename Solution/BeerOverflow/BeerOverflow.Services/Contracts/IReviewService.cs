using BeerOverflow.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Services.Contracts
{
    public interface IReviewService
    {
        ReviewDTO AddReview(string userName, string beerName, int rating, string rMessage);

    }
}
