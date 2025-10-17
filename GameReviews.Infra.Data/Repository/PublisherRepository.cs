using GameReviews.Domain.Interfaces;
using GameReviews.Domain.Model;
using GameReviews.Infra.Data.Context;

namespace GameReviews.Infra.Data.Repository;

public class PublisherRepository(GameReviewsContext db) : Repository<Publisher>(db), IPublisherRepository;