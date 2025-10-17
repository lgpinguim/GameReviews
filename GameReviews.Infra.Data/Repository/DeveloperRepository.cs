using GameReviews.Domain.Interfaces;
using GameReviews.Domain.Model;
using GameReviews.Infra.Data.Context;

namespace GameReviews.Infra.Data.Repository;

public class DeveloperRepository(GameReviewsContext db) : Repository<Developer>(db), IDeveloperRepository;