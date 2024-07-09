using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateAsyncScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Entity.Tag { Text = "web programlama", Url = "web-programlama", Colors = TagColors.danger },
                        new Entity.Tag { Text = "backend", Url = "backend", Colors = TagColors.primary },
                        new Entity.Tag { Text = "fullstack", Url = "fullstack", Colors = TagColors.secondary },
                        new Entity.Tag { Text = "frontend", Url = "frontend", Colors = TagColors.success },
                        new Entity.Tag { Text = "php", Url = "php", Colors = TagColors.warning }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new Entity.User { UserName = "vasfiolmez" },
                        new Entity.User { UserName = "ahmetyilmaz" }
                    );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.Net core",
                            Content = "Asp.Net core dersleri",
                            Url = "aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Image = "1.jpg",
                            Tags = context.Tags.Take(5).ToList(),
                            UserId = 1

                        },
                        new Post
                        {
                            Title = "Php",
                            Content = "Php dersleri",
                            Url = "php",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-2),
                            Image = "2.jpg",
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1

                        },
                        new Post
                        {
                            Title = "Django",
                            Content = "Django dersleri",
                            Url = "django",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-4),
                            Image = "3.jpg",
                            Tags = context.Tags.Take(1).ToList(),
                            UserId = 2

                        },
                        new Post
                        {
                            Title = "React",
                            Content = "React dersleri",
                            Url = "react",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-6),
                            Image = "3.jpg",
                            Tags = context.Tags.Take(1).ToList(),
                            UserId = 2

                        },
                        new Post
                        {
                            Title = "Angular",
                            Content = "Angular dersleri",
                            Url = "angular",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-8),
                            Image = "3.jpg",
                            Tags = context.Tags.Take(1).ToList(),
                            UserId = 2

                        },
                        new Post
                        {
                            Title = "Web Tasarım",
                            Content = "Web Tasarım dersleri",
                            Url = "web-tasarim",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Image = "3.jpg",
                            Tags = context.Tags.Take(1).ToList(),
                            UserId = 2

                        }

                    );
                    context.SaveChanges();
                }


            }


        }
    }
}