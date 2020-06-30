namespace IlyasCovidMovieMadness.Migrations
{
    using IlyasCovidMovieMadness.Controllers;
    using IlyasCovidMovieMadness.Models;
    using IlyasCovidMovieMadness.Services;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IlyasCovidMovieMadness.Context.cmmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IlyasCovidMovieMadness.Context.cmmDbContext context)
        {
            DateTime releaseDate1 = new DateTime(2002, 01, 01);
            DateTime releaseDate2 = new DateTime(1979, 01, 01);
            DateTime releaseDate3 = new DateTime(1979, 01, 01);
            var movies = new List<Movie>
            {
                new Movie { Title = "Resident Evil",
                    ReleaseDate = releaseDate1,
                    Description = "A special military unit fights a powerful, out-of-control supercomputer and hundreds of scientists who have mutated into flesh-eating creatures after a laboratory accident.",
                    Post  = new Post { MovieTitle = "Resident Evil",
                    PostRating = 4,
                    Text = "As a big fan of splatter and horror films i was gladly surprised when i watched this. The zombies here are a little bit faster though.",
                    DateCreated = DateTime.Now,
                    DateEdited = DateTime.Now,
                    Comments= new List<Comment>()
                        {
                            new Comment 
                            { 
                                UserName = "Anon", 
                                Text = "Imo RE, Best in the series, yada yada yada 5/5", 
                                UserRatig = 5, 
                                DateCreated = DateTime.Now, 
                                DateEdited = DateTime.Now 
                            },
                            new Comment 
                            {
                                UserName = "Anon2", 
                                Text = "Imo, RE Worst in the series, yada yada yada 1/5", 
                                UserRatig = 1, 
                                DateCreated = DateTime.Now, 
                                DateEdited = DateTime.Now 
                            },
                            new Comment 
                            {
                                UserName = "Anon3", 
                                Text = "Imo, RE fully agree with author, yada yada yada 4/5", 
                                UserRatig = 4, 
                                DateCreated = DateTime.Now, 
                                DateEdited = DateTime.Now 
                            }
                        }
                    }
                },
                new Movie { Title = "Alien", 
                    ReleaseDate = releaseDate2,
                    Description = "After a space merchant vessel receives an unknown transmission as a distress call, one of the crew is attacked by a mysterious life form and they soon realize that its life cycle has merely begun.", 
                    Post = new Post 
                    {
                        MovieTitle = "Alien", 
                        PostRating = 4, 
                        Text = "The further we go in special effects, the more movies show us and ignore the unseen, the more people will return to dark horrors like this one.",
                        DateCreated = DateTime.Now, 
                        DateEdited = DateTime.Now,
                        Comments= new List<Comment>()
                        {
                           new Comment 
                           { 
                               UserName = "Anon", 
                               Text = "Imo, Alien Best in the series, yada yada yada 5/5",
                               UserRatig = 5, 
                               DateCreated = DateTime.Now, 
                               DateEdited = DateTime.Now 
                           },
                           new Comment 
                           { 
                               UserName = "Anon2", 
                               Text = "Imo,Alien Worst in the series, yada yada yada 1/5", 
                               UserRatig = 1, 
                               DateCreated = DateTime.Now, 
                               DateEdited = DateTime.Now 
                           },
                           new Comment 
                           { 
                               UserName = "Anon3", 
                               Text = "Imo,Alien fully agree with author, yada yada yada 4/5", 
                               UserRatig = 5, 
                               DateCreated = DateTime.Now, 
                               DateEdited = DateTime.Now 
                           }
                        }
                    }
                },
                new Movie { Title = "Mad Max", 
                    ReleaseDate = releaseDate3, 
                    Description = "In a self-destructing world, a vengeful Australian policeman sets out to stop a violent motorcycle gang.",
                    Post = new Post { MovieTitle = "Mad Max", 
                        PostRating = 4, 
                        Text = "Slick stylish fun gem that isn't talked about enough! Mel Gibson and all the other Australian actors are incredible in this George Miller wild ride! ", 
                        DateCreated = DateTime.Now,
                        DateEdited = DateTime.Now,
                        Comments = new List<Comment>()
                        {
                            new Comment 
                            { 
                                UserName = "Anon", 
                                Text = "Imo, Mad Max Best in the series, yada yada yada 5/5", 
                                UserRatig = 5, 
                                DateCreated = DateTime.Now, 
                                DateEdited = DateTime.Now 
                            },
                            new Comment 
                            { 
                                UserName = "Anon2", 
                                Text = "Imo, Mad Max Worst in the series, yada yada yada 1/5", 
                                UserRatig = 1, 
                                DateCreated = DateTime.Now, 
                                DateEdited = DateTime.Now 
                            },
                            new Comment 
                            { 
                                UserName = "Anon3", 
                                Text = "Imo,Mad Max fully agree with author, yada yada yada 4/5", 
                                UserRatig = 3, 
                                DateCreated = DateTime.Now, 
                                DateEdited = DateTime.Now 
                            }
                        }
                    }
                }
            };
            context.Movie.AddRange(movies);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
