using Microsoft.EntityFrameworkCore;

namespace StudyingOnline.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new StudyingOnlineContext(
            serviceProvider.GetRequiredService<DbContextOptions<StudyingOnlineContext>>()))
        {
            // Look for any categories.
            if (!context.Category.Any())
            {
                context.Category.AddRange(
                    new Category
                    {
                        Name = "Computing",
                        Description = "Computer science courses"
                    },
                    new Category
                    {
                        Name = "Kitchen",
                        Description = "Courses with the best recipes"
                    },
                    new Category
                    {
                        Name = "Languages",
                        Description = "Learn new languages"
                    },
                    new Category
                    {
                        Name = "Art",
                        Description = "Painting, drawing"
                    },
                    new Category
                    {
                        Name = "Marketing",
                        Description = "They are marketing courses"
                    },
                    new Category
                    {
                        Name = "General interest",
                        Description = "Courses of all kinds for everyone"
                    }
                );
                context.SaveChanges();
            }

            // Look for any courses.
            if (!context.Course.Any())
            {
                context.Course.AddRange(
                    new Course
                    {
                        Name = "Java from scratch",
                        Description = "The Java platform is the name of an environment or computing platform originating from Sun Microsystems",
                        Duration = 8,
                        Price = 1500,
                        Image = null,
                        CategoryId = 1
                    },
                    new Course
                    {
                        Name = "C++",
                        Description = "C++ language course",
                        Duration = 4,
                        Price = 2500,
                        Image = null,
                        CategoryId = 1
                    },
                    new Course
                    {
                        Name = "Github",
                        Description = "Master git technology",
                        Duration = 2,
                        Price = 2800,
                        Image = null,
                        CategoryId = 1
                    },
                    new Course
                    {
                        Name = "Sweet",
                        Description = "Sweet recipes",
                        Duration = 3,
                        Price = 1200,
                        Image = null,
                        CategoryId = 2
                    },
                    new Course
                    {
                        Name = "Salty",
                        Description = "Salty recipes",
                        Duration = 4,
                        Price = 2200,
                        Image = null,
                        CategoryId = 2
                    },
                    new Course
                    {
                        Name = "English",
                        Description = "Learn english language",
                        Duration = 6,
                        Price = 1450,
                        Image = null,
                        CategoryId = 3
                    },
                    new Course
                    {
                        Name = "French",
                        Description = "Learn french language",
                        Duration = 6,
                        Price = 2480,
                        Image = null,
                        CategoryId = 3
                    },
                    new Course
                    {
                        Name = "Painting",
                        Description = "Classic painting",
                        Duration = 4,
                        Price = 2600,
                        Image = null,
                        CategoryId = 4
                    },
                    new Course
                    {
                        Name = "Drawing",
                        Description = "Classic drawing",
                        Duration = 6,
                        Price = 2900,
                        Image = null,
                        CategoryId = 4
                    },
                    new Course
                    {
                        Name = "Marketing",
                        Description = "Marketing course",
                        Duration = 2,
                        Price = 2500,
                        Image = null,
                        CategoryId = 5
                    },
                    new Course
                    {
                        Name = "Maths",
                        Description = "Maths course",
                        Duration = 12,
                        Price = 3200,
                        Image = null,
                        CategoryId = 6
                    }
                );
                context.SaveChanges();
            }

            // Look for any users.
            // if (!context.User.Any())
            // {
            //     context.User.AddRange(
            //     new User
            //     {
            //         Email = "admin@admin.com",
            //         Password = "$2a$11$YxCBF1F6Ttzq35acc6cPVuZvvYeQzJbJ0RXm4zRT5/eczh00Ylila",
            //         Name = "admin",
            //         Phone = "1234567890",
            //         IsAdmin = true
            //     },
            //     new User
            //     {
            //         Email = "no-admin@admin.com",
            //         Password = "$2a$11$YxCBF1F6Ttzq35acc6cPVuZvvYeQzJbJ0RXm4zRT5/eczh00Ylila",
            //         Name = "no-admin",
            //         Phone = "123456789",
            //         IsAdmin = false
            //     }
            //     );
            //     context.SaveChanges();
            // }
        }
    }
}