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
    public class ReviewService : IReviewService
    {
        private readonly BeerOverflowContext _beerOverflowContext;
        public ReviewService(BeerOverflowContext beerOverflowContext)
        {
            this._beerOverflowContext = beerOverflowContext;
        }

        public ReviewDTO AddReview(string userName, string beerName, int rating, string rMessage)
        {
            var user = _beerOverflowContext.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                throw new ArgumentNullException("User is null!");
            }
            var beer = _beerOverflowContext.Beers
                .Where(b => b.DateUnlisted == null)
                .FirstOrDefault(b => b.BeerName == beerName);

            if (beer == null)
            {
                throw new ArgumentNullException("Beer is null!");
            }


            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException("Rating is out of range!");
            }


            var userReview = new Review
            {
                UserId = user.Id,
                BeerId = beer.Id,
                Rating = rating,
                RMessage = rMessage,
                ReviewedOn = DateTime.UtcNow
            };
            try
            {
                _beerOverflowContext.Reviews.Add(userReview);
                _beerOverflowContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot add into database!");
            }
            var userReviewDTO = new ReviewDTO(userReview.Id, userReview.RMessage, userReview.Rating,
                userReview.User.UserName, userReview.UserId, userReview.Beer.BeerName,
                userReview.BeerId, userReview.ReviewedOn);

            return userReviewDTO;
        }

        public async Task<ReviewDTO> AddReview(int userId, int beerId, int rating, string rMessage)
        {
            var user = await _beerOverflowContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentNullException("User is null!");
            }

            //TODO Check error with await
            var existingReview = /*await*/ _beerOverflowContext.Reviews
                .Where(r=>r.BeerId == beerId)
                .Where(r => r.DeletedOn == null)
                .FirstOrDefault(r => r.UserId == userId);

            if (existingReview != null)
            {
                throw new InvalidOperationException("The user already reviewd this beer");
            }

            var beer = await _beerOverflowContext.Beers
                .Where(b => b.DateUnlisted == null)
                .FirstOrDefaultAsync(b => b.Id == beerId);

            if (beer == null)
            {
                throw new ArgumentNullException("Beer is null!");
            }

            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException("Rating is out of range!");
            }

            var userReview = new Review
            {
                UserId = user.Id,
                BeerId = beer.Id,
                Rating = rating,
                RMessage = rMessage,
                ReviewedOn = DateTime.UtcNow
            };
            try
            {
                await _beerOverflowContext.Reviews.AddAsync(userReview);
                await _beerOverflowContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot add into database!");
            }
            //TODO Where this dto is used
            var userReviewDTO = new ReviewDTO(userReview.Id, userReview.RMessage, userReview.Rating,
            userReview.User.UserName, userReview.UserId, userReview.Beer.BeerName,
            userReview.BeerId, userReview.ReviewedOn);

            return userReviewDTO;

        }


        public async Task<ReviewDTO> GetReviewAsync(int reviewId)
        {
            var review = await _beerOverflowContext.Reviews
                .Include(r=>r.User)
                .Include(r => r.Beer)
                .FirstOrDefaultAsync(r => r.Id == reviewId);


            if (review == null)
            {
                throw new ArgumentNullException("Missing review");
            }

            var reviewDTO = new ReviewDTO(review.Id,review.RMessage, review.Rating,review.User.Email, review.User.Id,
                review.Beer.BeerName, review.Beer.Id,review.ReviewedOn,review.DeletedOn);

            return reviewDTO;
        }
        public async Task<bool> ModifyReviewAsync(int reviewId,string rMessage,bool isDeleted)
        {
            var review = /*await */_beerOverflowContext.Reviews
                .FirstOrDefault(r => r.Id == reviewId);
            if (review==null)
            {
                throw new ArgumentNullException("Missing review");
            }

            if (!review.RMessage.Equals(rMessage))
                review.RMessage = rMessage;

            if (review.DeletedOn==null || isDeleted == true)
            {
                review.DeletedOn = DateTime.UtcNow;
            }

            try
            {
                await _beerOverflowContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot save changes!");
            }

        }
    }
}

