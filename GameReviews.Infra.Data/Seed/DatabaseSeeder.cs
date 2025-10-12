using GameReviews.Domain.Model;
using GameReviews.Infra.Data.Context;

namespace GameReviews.Infra.Data.Seed;

public static class DatabaseSeeder
{
    public static void Seed(GameReviewsContext context)
    {
        // Ensure database is created
        context.Database.EnsureCreated();

        // Check if data already exists
        if (context.Categories.Any())
            return; // Database has been seeded

        SeedCategories(context);
        SeedPlatforms(context);
        SeedDevelopers(context);
        SeedPublishers(context);
        SeedUsers(context);
        SeedGames(context);
        SeedLanguageSupport(context);
        SeedAchievements(context);
        SeedReviews(context);
    }

    private static void SeedCategories(GameReviewsContext context)
    {
        var categories = new List<Category>
        {
            new() { Name = "Action", Description = "Fast-paced gameplay with physical challenges", CreatedAt = DateTime.UtcNow },
            new() { Name = "Adventure", Description = "Story-driven exploration games", CreatedAt = DateTime.UtcNow },
            new() { Name = "RPG", Description = "Role-playing games with character progression", CreatedAt = DateTime.UtcNow },
            new() { Name = "Strategy", Description = "Tactical and strategic gameplay", CreatedAt = DateTime.UtcNow },
            new() { Name = "Simulation", Description = "Realistic simulation experiences", CreatedAt = DateTime.UtcNow },
            new() { Name = "Sports", Description = "Athletic and sports competitions", CreatedAt = DateTime.UtcNow },
            new() { Name = "Racing", Description = "Vehicle racing games", CreatedAt = DateTime.UtcNow },
            new() { Name = "Horror", Description = "Scary and suspenseful experiences", CreatedAt = DateTime.UtcNow },
            new() { Name = "Puzzle", Description = "Logic and problem-solving games", CreatedAt = DateTime.UtcNow },
            new() { Name = "Indie", Description = "Independent developer games", CreatedAt = DateTime.UtcNow }
        };
        context.Categories.AddRange(categories);
        context.SaveChanges();
    }

    private static void SeedPlatforms(GameReviewsContext context)
    {
        var platforms = new List<Platform>
        {
            new() { Name = "Windows", CreatedAt = DateTime.UtcNow },
            new() { Name = "macOS", CreatedAt = DateTime.UtcNow },
            new() { Name = "Linux", CreatedAt = DateTime.UtcNow },
            new() { Name = "PlayStation 5", CreatedAt = DateTime.UtcNow },
            new() { Name = "Xbox Series X/S", CreatedAt = DateTime.UtcNow },
            new() { Name = "Nintendo Switch", CreatedAt = DateTime.UtcNow },
            new() { Name = "Steam Deck", CreatedAt = DateTime.UtcNow }
        };
        context.Platforms.AddRange(platforms);
        context.SaveChanges();
    }

    private static void SeedDevelopers(GameReviewsContext context)
    {
        var developers = new List<Developer>
        {
            new() { Name = "CD Projekt Red", CreatedAt = DateTime.UtcNow },
            new() { Name = "FromSoftware", CreatedAt = DateTime.UtcNow },
            new() { Name = "Larian Studios", CreatedAt = DateTime.UtcNow },
            new() { Name = "Supergiant Games", CreatedAt = DateTime.UtcNow },
            new() { Name = "Valve", CreatedAt = DateTime.UtcNow },
            new() { Name = "Rockstar Games", CreatedAt = DateTime.UtcNow },
            new() { Name = "Naughty Dog", CreatedAt = DateTime.UtcNow },
            new() { Name = "Santa Monica Studio", CreatedAt = DateTime.UtcNow }
        };
        context.Developers.AddRange(developers);
        context.SaveChanges();
    }

    private static void SeedPublishers(GameReviewsContext context)
    {
        var publishers = new List<Publisher>
        {
            new() { Name = "CD Projekt", CreatedAt = DateTime.UtcNow },
            new() { Name = "Bandai Namco Entertainment", CreatedAt = DateTime.UtcNow },
            new() { Name = "Larian Studios", CreatedAt = DateTime.UtcNow },
            new() { Name = "Supergiant Games", CreatedAt = DateTime.UtcNow },
            new() { Name = "Valve", CreatedAt = DateTime.UtcNow },
            new() { Name = "Rockstar Games", CreatedAt = DateTime.UtcNow },
            new() { Name = "Sony Interactive Entertainment", CreatedAt = DateTime.UtcNow }
        };
        context.Publishers.AddRange(publishers);
        context.SaveChanges();
    }

    private static void SeedUsers(GameReviewsContext context)
    {
        var users = new List<User>
        {
            new() { Name = "John Smith", Email = "john.smith@example.com", CreatedAt = DateTime.UtcNow, TotalReviews = 0 },
            new() { Name = "Sarah Johnson", Email = "sarah.j@example.com", ProfilePictureUrl = "https://example.com/profiles/sarah.jpg", CreatedAt = DateTime.UtcNow, TotalReviews = 0 },
            new() { Name = "Michael Chen", Email = "mchen@example.com", CreatedAt = DateTime.UtcNow, TotalReviews = 0 },
            new() { Name = "Emma Williams", Email = "emma.w@example.com", ProfilePictureUrl = "https://example.com/profiles/emma.jpg", CreatedAt = DateTime.UtcNow, TotalReviews = 0 },
            new() { Name = "David Martinez", Email = "david.m@example.com", CreatedAt = DateTime.UtcNow, TotalReviews = 0 }
        };
        context.Users.AddRange(users);
        context.SaveChanges();
    }

    private static void SeedGames(GameReviewsContext context)
    {
        var categories = context.Categories.ToList();
        var platforms = context.Platforms.ToList();
        var developers = context.Developers.ToList();
        var publishers = context.Publishers.ToList();

        var games = new List<Game>
        {
            new()
            {
                Title = "The Witcher 3: Wild Hunt",
                Description = "An epic open-world RPG adventure following Geralt of Rivia",
                ReleaseDate = new DateTime(2015, 5, 19),
                Price = 39.99m,
                CoverImageUrl = "https://example.com/covers/witcher3.jpg",
                TrailerUrl = "https://example.com/trailers/witcher3.mp4",
                MetacriticScore = 93,
                IsEarlyAccess = false,
                AgeRating = "M",
                LastUpdated = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Categories = new List<Category> { categories[2], categories[1] }, // RPG, Adventure
                Platforms = new List<Platform> { platforms[0], platforms[3], platforms[4] }, // Windows, PS5, Xbox
                Developers = new List<Developer> { developers[0] }, // CD Projekt Red
                Publishers = new List<Publisher> { publishers[0] }, // CD Projekt
                LanguageSupport = new List<LanguageSupport>(),
                Achievements = new List<Achievement>(),
                Reviews = new List<Review>()
            },
            new()
            {
                Title = "Elden Ring",
                Description = "A vast fantasy action RPG created by FromSoftware and George R.R. Martin",
                ReleaseDate = new DateTime(2022, 2, 25),
                Price = 59.99m,
                CoverImageUrl = "https://example.com/covers/eldenring.jpg",
                TrailerUrl = "https://example.com/trailers/eldenring.mp4",
                MetacriticScore = 96,
                IsEarlyAccess = false,
                AgeRating = "M",
                LastUpdated = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Categories = new List<Category> { categories[2], categories[0] }, // RPG, Action
                Platforms = new List<Platform> { platforms[0], platforms[3], platforms[4] },
                Developers = new List<Developer> { developers[1] }, // FromSoftware
                Publishers = new List<Publisher> { publishers[1] }, // Bandai Namco
                LanguageSupport = new List<LanguageSupport>(),
                Achievements = new List<Achievement>(),
                Reviews = new List<Review>()
            },
            new()
            {
                Title = "Baldur's Gate 3",
                Description = "A story-rich, party-based RPG set in the Dungeons & Dragons universe",
                ReleaseDate = new DateTime(2023, 8, 3),
                Price = 59.99m,
                CoverImageUrl = "https://example.com/covers/bg3.jpg",
                TrailerUrl = "https://example.com/trailers/bg3.mp4",
                MetacriticScore = 96,
                IsEarlyAccess = false,
                AgeRating = "M",
                LastUpdated = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Categories = new List<Category> { categories[2], categories[1], categories[3] }, // RPG, Adventure, Strategy
                Platforms = new List<Platform> { platforms[0], platforms[1], platforms[3] },
                Developers = new List<Developer> { developers[2] }, // Larian Studios
                Publishers = new List<Publisher> { publishers[2] }, // Larian Studios
                LanguageSupport = new List<LanguageSupport>(),
                Achievements = new List<Achievement>(),
                Reviews = new List<Review>()
            },
            new()
            {
                Title = "Hades",
                Description = "A rogue-like dungeon crawler from the creators of Bastion and Transistor",
                ReleaseDate = new DateTime(2020, 9, 17),
                Price = 24.99m,
                CoverImageUrl = "https://example.com/covers/hades.jpg",
                TrailerUrl = "https://example.com/trailers/hades.mp4",
                MetacriticScore = 93,
                IsEarlyAccess = false,
                AgeRating = "T",
                LastUpdated = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Categories = new List<Category> { categories[0], categories[2], categories[9] }, // Action, RPG, Indie
                Platforms = new List<Platform> { platforms[0], platforms[5] },
                Developers = new List<Developer> { developers[3] }, // Supergiant Games
                Publishers = new List<Publisher> { publishers[3] }, // Supergiant Games
                LanguageSupport = new List<LanguageSupport>(),
                Achievements = new List<Achievement>(),
                Reviews = new List<Review>()
            },
            new()
            {
                Title = "Portal 2",
                Description = "A mind-bending puzzle-platformer with innovative gameplay mechanics",
                ReleaseDate = new DateTime(2011, 4, 19),
                Price = 9.99m,
                CoverImageUrl = "https://example.com/covers/portal2.jpg",
                TrailerUrl = "https://example.com/trailers/portal2.mp4",
                MetacriticScore = 95,
                IsEarlyAccess = false,
                AgeRating = "E10+",
                LastUpdated = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
                Categories = new List<Category> { categories[8], categories[1] }, // Puzzle, Adventure
                Platforms = new List<Platform> { platforms[0], platforms[1], platforms[2] },
                Developers = new List<Developer> { developers[4] }, // Valve
                Publishers = new List<Publisher> { publishers[4] }, // Valve
                LanguageSupport = new List<LanguageSupport>(),
                Achievements = new List<Achievement>(),
                Reviews = new List<Review>()
            }
        };

        context.Games.AddRange(games);
        context.SaveChanges();
    }

    private static void SeedLanguageSupport(GameReviewsContext context)
    {
        var games = context.Games.ToList();

        var languageSupports = new List<LanguageSupport>();

        // The Witcher 3 language support
        languageSupports.AddRange(new[]
        {
            new LanguageSupport { GameId = games[0].Id, Game = games[0], Language = "English", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[0].Id, Game = games[0], Language = "Spanish", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[0].Id, Game = games[0], Language = "French", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[0].Id, Game = games[0], Language = "German", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[0].Id, Game = games[0], Language = "Portuguese", Interface = true, Audio = false, Subtitles = true, CreatedAt = DateTime.UtcNow }
        });

        // Elden Ring language support
        languageSupports.AddRange(new[]
        {
            new LanguageSupport { GameId = games[1].Id, Game = games[1], Language = "English", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[1].Id, Game = games[1], Language = "Japanese", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[1].Id, Game = games[1], Language = "Spanish", Interface = true, Audio = false, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[1].Id, Game = games[1], Language = "French", Interface = true, Audio = false, Subtitles = true, CreatedAt = DateTime.UtcNow }
        });

        // Baldur's Gate 3 language support
        languageSupports.AddRange(new[]
        {
            new LanguageSupport { GameId = games[2].Id, Game = games[2], Language = "English", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[2].Id, Game = games[2], Language = "Spanish", Interface = true, Audio = false, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[2].Id, Game = games[2], Language = "German", Interface = true, Audio = false, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[2].Id, Game = games[2], Language = "Portuguese", Interface = true, Audio = false, Subtitles = true, CreatedAt = DateTime.UtcNow }
        });

        // Hades language support
        languageSupports.AddRange(new[]
        {
            new LanguageSupport { GameId = games[3].Id, Game = games[3], Language = "English", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[3].Id, Game = games[3], Language = "Spanish", Interface = true, Audio = false, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[3].Id, Game = games[3], Language = "French", Interface = true, Audio = false, Subtitles = true, CreatedAt = DateTime.UtcNow }
        });

        // Portal 2 language support
        languageSupports.AddRange(new[]
        {
            new LanguageSupport { GameId = games[4].Id, Game = games[4], Language = "English", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[4].Id, Game = games[4], Language = "Spanish", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[4].Id, Game = games[4], Language = "French", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow },
            new LanguageSupport { GameId = games[4].Id, Game = games[4], Language = "German", Interface = true, Audio = true, Subtitles = true, CreatedAt = DateTime.UtcNow }
        });

        context.LanguageSupports.AddRange(languageSupports);
        context.SaveChanges();
    }

    private static void SeedAchievements(GameReviewsContext context)
    {
        var games = context.Games.ToList();

        var achievements = new List<Achievement>();

        // The Witcher 3 achievements
        achievements.AddRange(new[]
        {
            new Achievement { GameId = games[0].Id, Game = games[0], Name = "Lilac and Gooseberries", Description = "Find Yennefer of Vengerberg", IconUrl = "https://example.com/icons/w3_ach1.png", UnlockPercentage = 85.5m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[0].Id, Game = games[0], Name = "Woodland Spirit", Description = "Complete the Leshen contract", IconUrl = "https://example.com/icons/w3_ach2.png", UnlockPercentage = 45.2m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[0].Id, Game = games[0], Name = "Master Marksman", Description = "Kill 50 enemies with crossbow bolt headshots", IconUrl = "https://example.com/icons/w3_ach3.png", UnlockPercentage = 12.8m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[0].Id, Game = games[0], Name = "The Final Trial", Description = "Complete the game", IconUrl = "https://example.com/icons/w3_ach4.png", UnlockPercentage = 38.7m, IsHidden = true, CreatedAt = DateTime.UtcNow }
        });

        // Elden Ring achievements
        achievements.AddRange(new[]
        {
            new Achievement { GameId = games[1].Id, Game = games[1], Name = "Elden Lord", Description = "Become the Elden Lord", IconUrl = "https://example.com/icons/er_ach1.png", UnlockPercentage = 34.2m, IsHidden = true, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[1].Id, Game = games[1], Name = "Godrick the Grafted", Description = "Defeat Godrick the Grafted", IconUrl = "https://example.com/icons/er_ach2.png", UnlockPercentage = 67.8m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[1].Id, Game = games[1], Name = "Great Rune", Description = "Restore a Great Rune", IconUrl = "https://example.com/icons/er_ach3.png", UnlockPercentage = 55.3m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[1].Id, Game = games[1], Name = "Legendary Armaments", Description = "Acquire all legendary armaments", IconUrl = "https://example.com/icons/er_ach4.png", UnlockPercentage = 5.7m, IsHidden = false, CreatedAt = DateTime.UtcNow }
        });

        // Baldur's Gate 3 achievements
        achievements.AddRange(new[]
        {
            new Achievement { GameId = games[2].Id, Game = games[2], Name = "Descent from Avernus", Description = "Complete the Prologue", IconUrl = "https://example.com/icons/bg3_ach1.png", UnlockPercentage = 89.4m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[2].Id, Game = games[2], Name = "Absolute Power", Description = "Discover the truth about the Absolute", IconUrl = "https://example.com/icons/bg3_ach2.png", UnlockPercentage = 42.1m, IsHidden = true, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[2].Id, Game = games[2], Name = "Critical Hit", Description = "Complete the game in Tactician mode", IconUrl = "https://example.com/icons/bg3_ach3.png", UnlockPercentage = 8.3m, IsHidden = false, CreatedAt = DateTime.UtcNow }
        });

        // Hades achievements
        achievements.AddRange(new[]
        {
            new Achievement { GameId = games[3].Id, Game = games[3], Name = "Is There No Escape?", Description = "Attempt to escape", IconUrl = "https://example.com/icons/hades_ach1.png", UnlockPercentage = 98.2m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[3].Id, Game = games[3], Name = "Fated Authority", Description = "Complete the game", IconUrl = "https://example.com/icons/hades_ach2.png", UnlockPercentage = 47.6m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[3].Id, Game = games[3], Name = "The Useless Trinket", Description = "Earn the Pact of Punishment", IconUrl = "https://example.com/icons/hades_ach3.png", UnlockPercentage = 25.9m, IsHidden = false, CreatedAt = DateTime.UtcNow }
        });

        // Portal 2 achievements
        achievements.AddRange(new[]
        {
            new Achievement { GameId = games[4].Id, Game = games[4], Name = "Wake Up Call", Description = "Survive the manual override", IconUrl = "https://example.com/icons/p2_ach1.png", UnlockPercentage = 92.7m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[4].Id, Game = games[4], Name = "Drop Box", Description = "Place a cube on a button", IconUrl = "https://example.com/icons/p2_ach2.png", UnlockPercentage = 88.3m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[4].Id, Game = games[4], Name = "Tater Tote", Description = "Carry the PotatOS safely through the entire facility", IconUrl = "https://example.com/icons/p2_ach3.png", UnlockPercentage = 34.5m, IsHidden = false, CreatedAt = DateTime.UtcNow },
            new Achievement { GameId = games[4].Id, Game = games[4], Name = "Good Listener", Description = "Take GLaDOS's advice", IconUrl = "https://example.com/icons/p2_ach4.png", UnlockPercentage = 15.2m, IsHidden = true, CreatedAt = DateTime.UtcNow },
        });

        context.Achievements.AddRange(achievements);
        context.SaveChanges();
    }

    private static void SeedReviews(GameReviewsContext context)
    {
        var games = context.Games.ToList();
        var users = context.Users.ToList();

        var reviews = new List<Review>
        {
            new()
            {
                GameId = games[0].Id,
                Game = games[0],
                UserId = users[0].Id,
                User = users[0],
                Recommended = true,
                UserName = users[0].Name,
                ReviewText = "Absolutely phenomenal game! The story is gripping, the world is vast and beautiful, and the characters are memorable. Easily one of the best RPGs ever made.",
                HoursPlayed = 156.5f,
                DatePosted = DateTime.UtcNow.AddDays(-30),
                HelpfulCount = 245,
                UnhelpfulCount = 12,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-30)
            },
            new()
            {
                GameId = games[0].Id,
                Game = games[0],
                UserId = users[1].Id,
                User = users[1],
                Recommended = true,
                UserName = users[1].Name,
                ReviewText = "The Witcher 3 set a new standard for open-world RPGs. The side quests are better than most games' main stories. A masterpiece.",
                HoursPlayed = 203.2f,
                DatePosted = DateTime.UtcNow.AddDays(-45),
                HelpfulCount = 189,
                UnhelpfulCount = 8,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-45)
            },
            new()
            {
                GameId = games[1].Id,
                Game = games[1],
                UserId = users[2].Id,
                User = users[2],
                Recommended = true,
                UserName = users[2].Name,
                ReviewText = "Elden Ring is a masterclass in game design. The open world is breathtaking, the combat is challenging but fair, and there's always something new to discover.",
                HoursPlayed = 287.8f,
                DatePosted = DateTime.UtcNow.AddDays(-20),
                HelpfulCount = 432,
                UnhelpfulCount = 25,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-20)
            },
            new()
            {
                GameId = games[1].Id,
                Game = games[1],
                UserId = users[3].Id,
                User = users[3],
                Recommended = false,
                UserName = users[3].Name,
                ReviewText = "Beautiful game but extremely difficult. Not for casual players. I appreciate the design but it's just too punishing for me.",
                HoursPlayed = 28.5f,
                DatePosted = DateTime.UtcNow.AddDays(-15),
                HelpfulCount = 78,
                UnhelpfulCount = 45,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-15)
            },
            new()
            {
                GameId = games[2].Id,
                Game = games[2],
                UserId = users[0].Id,
                User = users[0],
                Recommended = true,
                UserName = users[0].Name,
                ReviewText = "Baldur's Gate 3 is simply incredible. The amount of choice and consequence is staggering. Every playthrough feels unique. Best RPG of the decade!",
                HoursPlayed = 142.3f,
                DatePosted = DateTime.UtcNow.AddDays(-10),
                HelpfulCount = 567,
                UnhelpfulCount = 18,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-10)
            },
            new()
            {
                GameId = games[2].Id,
                Game = games[2],
                UserId = users[4].Id,
                User = users[4],
                Recommended = true,
                UserName = users[4].Name,
                ReviewText = "As a D&D fan, this is everything I dreamed of. The adaptation is faithful yet accessible. The multiplayer is fantastic with friends!",
                HoursPlayed = 98.7f,
                DatePosted = DateTime.UtcNow.AddDays(-25),
                HelpfulCount = 201,
                UnhelpfulCount = 9,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-25)
            },
            new()
            {
                GameId = games[3].Id,
                Game = games[3],
                UserId = users[1].Id,
                User = users[1],
                Recommended = true,
                UserName = users[1].Name,
                ReviewText = "Hades is addictive perfection. The roguelike gameplay combined with an engaging story is brilliant. Can't stop playing 'just one more run'!",
                HoursPlayed = 84.2f,
                DatePosted = DateTime.UtcNow.AddDays(-35),
                HelpfulCount = 345,
                UnhelpfulCount = 7,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-35)
            },
            new()
            {
                GameId = games[3].Id,
                Game = games[3],
                UserId = users[2].Id,
                User = users[2],
                Recommended = true,
                UserName = users[2].Name,
                ReviewText = "Supergiant Games knocked it out of the park. Amazing art, music, voice acting, and gameplay. A complete package.",
                HoursPlayed = 67.5f,
                DatePosted = DateTime.UtcNow.AddDays(-50),
                HelpfulCount = 278,
                UnhelpfulCount = 5,
                ReceivedForFree = true,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-50)
            },
            new()
            {
                GameId = games[4].Id,
                Game = games[4],
                UserId = users[3].Id,
                User = users[3],
                Recommended = true,
                UserName = users[3].Name,
                ReviewText = "Portal 2 is a timeless classic. The puzzles are clever, the writing is hilarious, and the co-op mode is outstanding. A must-play.",
                HoursPlayed = 15.8f,
                DatePosted = DateTime.UtcNow.AddDays(-60),
                HelpfulCount = 512,
                UnhelpfulCount = 3,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-60)
            },
            new()
            {
                GameId = games[4].Id,
                Game = games[4],
                UserId = users[4].Id,
                User = users[4],
                Recommended = true,
                UserName = users[4].Name,
                ReviewText = "Still one of the best puzzle games ever made. GLaDOS is iconic. If you haven't played this yet, what are you waiting for?",
                HoursPlayed = 22.3f,
                DatePosted = DateTime.UtcNow.AddDays(-40),
                HelpfulCount = 421,
                UnhelpfulCount = 11,
                ReceivedForFree = false,
                EarlyAccessReview = false,
                CreatedAt = DateTime.UtcNow.AddDays(-40)
            }
        };

        context.Reviews.AddRange(reviews);
        context.SaveChanges();

        foreach (var user in users)
        {
            user.TotalReviews = reviews.Count(r => r.UserId == user.Id);
        }
        context.SaveChanges();
    }
}