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
                new Languages {Id = 8, Value = "French"},
            };
            foreach (var language in languages)
            {
                context.Add(language);
            }

            context.SaveChanges();
        }
    }
}