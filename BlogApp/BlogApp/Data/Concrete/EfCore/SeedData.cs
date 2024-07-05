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
                        new Entity.Tag { Text = "web programlama" },
                        new Entity.Tag { Text = "backend" },
                        new Entity.Tag { Text = "fullstack" },
                        new Entity.Tag { Text = "frontend" },
                        new Entity.Tag { Text = "php" }
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
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1

                        },
                        new Post
                        {
                            Title = "Php",
                            Content = "Php dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1

                        },
                        new Post
                        {
                            Title = "Django",
                            Content = "Django dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-2),
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