using GameReviews.Domain.Interfaces;
using GameReviews.Domain.Model;
using GameReviews.Infra.Data.Context;

namespace GameReviews.Infra.Data.Repository;

public class ReviewRepository(GameReviewsContext db) : Repository<Review>(db), IReviewRepository;