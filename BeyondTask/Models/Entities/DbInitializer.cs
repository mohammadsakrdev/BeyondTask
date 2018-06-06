using BeyondTask.Models.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeyondTask.Models.Entities
{
    public static class DbInitializer
    {
        public static void Initialize(RepositoryContext context)
        {
            context.Database.EnsureCreated();

            // Look for any gender.
            if (context.Gender.Any())
            {
                return;   // DB has been seeded
            }

            var genders = new Gender[]
            {
            new Gender{GenderName = "Male"},
            new Gender{GenderName = "Female"},
            };
            foreach (Gender g in genders)
            {
                context.Gender.Add(g);
            }
            context.SaveChanges();
        }
    }
}
