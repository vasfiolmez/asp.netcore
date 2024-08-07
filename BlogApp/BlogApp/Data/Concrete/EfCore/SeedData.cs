using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url = "web-programlama", Colors = TagColors.warning },
                        new Tag { Text = "backend", Url = "backend", Colors = TagColors.info },
                        new Tag { Text = "frontend", Url = "frontend", Colors = TagColors.success },
                        new Tag { Text = "fullstack", Url = "fullstack", Colors = TagColors.secondary },
                        new Tag { Text = "php", Url = "php", Colors = TagColors.primary }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "sadikturan", Image = "p1.jpg", Name = "Sadık Turan", Email = "sadikturan@gmail.com", Password = "123456" },
                        new User { UserName = "vasfiolmez", Image = "p2.jpg", Name = "Vasfi Ölmez", Email = "info@vasfiolmez.com", Password = "123456" }
                    );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.net core",
                            Content = "Asp.net core dersleri",
                            Description = "Asp.net core dersleri",
                            Url = "aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment> {
                                new Comment { Text = "iyi bir kurs", PublishedOn = DateTime.Now.AddDays(-30), UserId = 1},
                                new Comment { Text = "çok faydalandığım bir kurs", PublishedOn = DateTime.Now.AddDays(-30), UserId = 2},
                            }
                        },
                        new Post
                        {
                            Title = "Php",
                            Content = "Php core dersleri",
                            Description = "Asp.net core dersleri",
                            Url = "php",
                            IsActive = true,
                            Image = "2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Django",
                            Content = "Django dersleri",
                            Description = "Asp.net core dersleri",
                            Url = "django",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                        ,
                        new Post
                        {
                            Title = "React Dersleri",
                            Content = "React dersleri",
                            Description = "Asp.net core dersleri",
                            Url = "react-dersleri",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                        ,
                        new Post
                        {
                            Title = "Angular",
                            Content = "Angular dersleri",
                            Description = "Asp.net core dersleri",
                            Url = "angular",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                        ,
                        new Post
                        {
                            Title = "Web Tasarım",
                            Content = "Web tasarım dersleri",
                            Description = "Asp.net core dersleri",
                            Url = "web-tasarim",
                            IsActive = true,
                            Image = "3.jpg",
                            PublishedOn = DateTime.Now.AddDays(-60),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}