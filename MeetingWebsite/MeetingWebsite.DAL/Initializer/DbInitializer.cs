using System;
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
                new PurposeOfDating {Id = 2, Value = "Spend the evening"},
                new PurposeOfDating {Id = 3, Value = "Permanent relationship"},
                new PurposeOfDating {Id = 4, Value = "Travel together"}
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

            var genders = new Gender[]
            {
                new Gender {Id = 1, Value = "Male"},
                new Gender {Id = 2, Value = "Female"},
                new Gender {Id = 3, Value = "Other"}
            };
            foreach (var gender in genders)
            {
                context.Add(gender);
            }

            context.SaveChanges();

            var zodiacSigns = new ZodiacSigns[]
            {
                new ZodiacSigns {Id = 1, Value = "Aries"},
                new ZodiacSigns {Id = 2, Value = "Taurus"},
                new ZodiacSigns {Id = 3, Value = "Gemini"},
                new ZodiacSigns {Id = 4, Value = "Cancer"},
                new ZodiacSigns {Id = 5, Value = "Leo"},
                new ZodiacSigns {Id = 6, Value = "Virgo"},
                new ZodiacSigns {Id = 7, Value = "Libra"},
                new ZodiacSigns {Id = 8, Value = "Scorpio"},
                new ZodiacSigns {Id = 9, Value = "Sagittarius"},
                new ZodiacSigns {Id = 10, Value = "Capricorn"},
                new ZodiacSigns {Id = 11, Value = "Aquarius"},
                new ZodiacSigns {Id = 12, Value = "Pisces"}
            };
            foreach (var zodiacSign in zodiacSigns)
            {
                context.Add(zodiacSign);
            }

            context.SaveChanges();

            var educations = new Education[]
            {
                new Education {Id = 1, Value = "secondary education"},
                new Education {Id = 2, Value = "secondary (complete) education"},
                new Education {Id = 3, Value = "secondary (vocational) education"},
                new Education {Id = 4, Value = "undergraduate higher education"},
                new Education {Id = 5, Value = "magistracy"},
                new Education {Id = 6, Value = "ViPostgraduate (internship, residency, adjuncture) (if you are a candidate of science)rgo"},
                new Education {Id = 7, Value = "doctoral studies (for the degree of doctor of science)"}
            };
            foreach (var education in educations)
            {
                context.Add(education);
            }

            context.SaveChanges();

            var financialSituations = new FinancialSituation[]
            {
                new FinancialSituation {Id = 1, Value = "Discussed (He did not decide)"},
                new FinancialSituation {Id = 2, Value = "Minimum (Up to 50 thousand rubles)"},
                new FinancialSituation {Id = 3, Value = "Practical (Up to 100 thousand rubles)"},
                new FinancialSituation {Id = 4, Value = "Moderate (Up to 150 thousand rubles)"},
                new FinancialSituation {Id = 5, Value = "Significant (Up to 300 thousand rubles)"},
                new FinancialSituation {Id = 6, Value = "High (300 thousand rubles and more)"}
            };
            foreach (var financialSituation in financialSituations)
            {
                context.Add(financialSituation);
            }

            context.SaveChanges();

            var nationalities = new Nationality[]
            {
                new Nationality {Id = 1, Value = "Belarusian"},
                new Nationality {Id = 2, Value = "Russian "},
                new Nationality {Id = 3, Value = "other"}
            };
            foreach (var nationality in nationalities)
            {
                context.Add(nationality);
            }

            context.SaveChanges();
        }
    }
}