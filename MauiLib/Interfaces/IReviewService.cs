using MauiLib.Models;

namespace MauiLib.Interfaces
{
    public interface IReviewService
    {
        Task<Review> CreateReviewAsync(Review review);

        Task<Review> UpdateReviewAsync(Review review);

        Task<Review> GetReviewByIdAsync(int id);

        Task<IEnumerable<Review>> GetAllReviews();

        void DeleteReview(Review review);
    }
}