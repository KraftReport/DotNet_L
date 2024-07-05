using AutoMapper;
using Pokemon.Data;
using Pokemon.Interfaces;
using Pokemon.Models;

namespace Pokemon.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ReviewRepository(DataContext context,IMapper mapper) 
        {
            _dataContext = context;
            _mapper = mapper;
        }
        public bool CreateReview(Review review)
        {
           _dataContext.Add(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _dataContext.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _dataContext.RemoveRange(reviews);
            return Save();
        }

        public Review GetReview(int ReviewId)
        {
            return _dataContext.Reviews.Where(r => r.Id == ReviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _dataContext.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int PokeId)
        {
            return _dataContext.Reviews.Where(r => r.Pokemon.Id == PokeId).ToList();
        }

        public bool ReviewExists(int ReviewId)
        {
            return _dataContext.Reviews.Any(r => r.Id == ReviewId);
        }

        public bool UpdateReview(Review review)
        {
            _dataContext.Update(review);
            return Save();
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
