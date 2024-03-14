using RecipeBook.Domain.Entities;

namespace RecipeBook.Domain.Interfaces
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