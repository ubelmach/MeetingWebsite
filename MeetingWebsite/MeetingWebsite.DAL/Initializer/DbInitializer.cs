using System.Linq;
using MeetingWebsite.DAL.EF;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.DAL.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(MeetingDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.PurposeOfDatings.Any())
            {
                return;
            }

            var purposes = new PurposeOfDating[]
            {
                new PurposeOfDating {Id = 1, Value = "I will become a sponsor"},
                new PurposeOfDating {Id = 3, Value = "Spend the evening"},
                new PurposeOfDating {Id = 4, Value = "Permanent relationship"},
                new PurposeOfDating {Id = 5, Value = "Travel together"}
            };

            foreach (var purpose in purposes)
            {
                context.Add(purpose);
            }

            context.SaveChanges();

            var languages = new Languages[]
            {
                new Languages {Id = 1, Value = "Chinese"},
                new Languages {Id = 2, Value = "English"},
                new Languages {Id = 3, Value = "Spanish"},
                new Languages {Id = 4, Value = "Arabic"},
                new Languages {Id = 5, Value = "Russian"},
                new Languages {Id = 6, Value = "Portuguese"},
                new Languages {Id = 7, Value = "German"},
                new Languages {Id = 8, Value = "French"}
            };
            foreach (var language in languages)
            {
                context.Add(language);
            }

            context.SaveChanges();


            var badHabits = new BadHabits[]
            {
                new BadHabits {Id = 1, Value = "Smoker"},
                new BadHabits {Id = 2, Value = "I do not smoke"},
                new BadHabits {Id = 3, Value = "I sometimes smoke"},
                new BadHabits {Id = 4, Value = "I smoke in the company"},
                new BadHabits {Id = 5, Value = "I like to drink"},
                new BadHabits {Id = 6, Value = "Sometimes drink"},
                new BadHabits {Id = 7, Value = "I drink for the company"},
                new BadHabits {Id = 8, Value = "I do not drink"}
            };
            foreach (var badHabit in badHabits)
            {
                context.Add(badHabit);
            }

            context.SaveChanges();

            var interests = new Interests[]
            {
                new Interests {Id = 1, Value = "Sport"},
                new Interests {Id = 2, Value = "Art"},
                new Interests {Id = 3, Value = "IT"},
                new Interests {Id = 4, Value = "Finance and Investments"},
                new Interests {Id = 5, Value = "The science"},
                new Interests {Id = 6, Value = "Travels"},
                new Interests {Id = 7, Value = "Bars and restaurants"},
                new Interests {Id = 8, Value = "Extreme"},
                new Interests {Id = 9, Value = "Movie"},
                new Interests {Id = 10, Value = "Music"},
                new Interests {Id = 11, Value = "Literature"},
                new Interests {Id = 12, Value = "Shopping"},
                new Interests {Id = 13, Value = "Dancing"},
                new Interests {Id = 14, Value = "Cars"},
                new Interests {Id = 15, Value = "Cooking"}
            };
            foreach (var interest in interests)
            {
                context.Add(interest);
            }

            context.SaveChanges();
        }
    }
}