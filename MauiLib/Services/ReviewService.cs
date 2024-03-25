using MauiLib.Interfaces;
using MauiLib.Models;

namespace MauiLib.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;

        public ReviewService(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            await _repository.CreateAsync(review);
            await _repository.SaveChangesAsync();
            return review;
        }

        public async void DeleteReview(Review review)
        {
            await _repository.Delete(review.Id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id) ?? throw new ArgumentException("Review Id Doesnt Exist/not found");
        }

        public async Task<Review> UpdateReviewAsync(Review review)
        {
            return await _repository.UpdateAsync(review);
        }
    }
}