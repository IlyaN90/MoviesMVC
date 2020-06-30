using IlyasCovidMovieMadness.Context;
using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Services
{
    public class DataSeed : DropCreateDatabaseAlways<cmmDbContext>
    {
        protected override void Seed(cmmDbContext context)
        {
            IList<Movie> defaultMovies = new List<Movie>();
            DateTime releaseDate1 = new DateTime(2002, 01, 01);
            DateTime releaseDate2 = new DateTime(1979, 01, 01);
            DateTime releaseDate3 = new DateTime(1979, 01, 01);

            defaultMovies.Add(new Movie() { Title = "Resident Evil", ReleaseDate=releaseDate1, Description = "A special military unit fights a powerful, out-of-control supercomputer and hundreds of scientists who have mutated into flesh-eating creatures after a laboratory accident." });
            defaultMovies.Add(new Movie() { Title = "Alien", ReleaseDate = releaseDate2, Description = "After a space merchant vessel receives an unknown transmission as a distress call, one of the crew is attacked by a mysterious life form and they soon realize that its life cycle has merely begun." });
            defaultMovies.Add(new Movie() { Title = "Mad Max", ReleaseDate = releaseDate3, Description = "In a self-destructing world, a vengeful Australian policeman sets out to stop a violent motorcycle gang." });

            defaultMovies[0].Post = new Post { MovieTitle = "Resident Evil", PostRating = 4, Text= "As a big fan of splatter and horror films i was gladly surprised when i watched this. I haven't played the game so i had no idea what to expect and had nothing to compare with. I really feel that this pays homage to the old zombie films at least to an extent. The zombies here are a little bit faster though.", DateCreated=DateTime.Now, DateEdited=DateTime.Now };
            defaultMovies[1].Post = new Post { MovieTitle = "Alien", PostRating = 4, Text = "The further we go in special effects, the more movies show us and ignore the unseen, the more people will return to dark horrors like this one.It's hard to look at this film without considering the sequels and knowing the alien itself, however when made the alien was mostly unseen and a mystery. It is difficult to forget what you have seen, but it iss important to approach this film first if possible rather than joining the series late", DateCreated = DateTime.Now, DateEdited = DateTime.Now };
            defaultMovies[2].Post = new Post { MovieTitle = "Mad Max", PostRating = 4, Text = "Slick stylish fun gem that isn't talked about enough! Mel Gibson and all the other Australian actors are incredible in this George Miller wild ride! Not much to be said except it's got awesome characters that should be praised more.", DateCreated = DateTime.Now, DateEdited = DateTime.Now };

            defaultMovies[0].Post.Comments.Add(new Comment { UserName = "Anon", Text = "Imo, Best in the series, yada yada yada 5/5", UserRatig = 5, DateCreated = DateTime.Now, DateEdited = DateTime.Now });
            defaultMovies[1].Post.Comments.Add(new Comment { UserName = "Anon", Text = "Imo, Best in the series, yada yada yada 5/5", UserRatig = 5, DateCreated = DateTime.Now, DateEdited = DateTime.Now });
            defaultMovies[2].Post.Comments.Add(new Comment { UserName = "Anon", Text = "Imo, Best in the series, yada yada yada 5/5", UserRatig = 5, DateCreated = DateTime.Now, DateEdited = DateTime.Now });

            defaultMovies[0].Post.Comments.Add(new Comment { UserName = "Anon2", Text = "Imo, Worst in the series, yada yada yada 1/5", UserRatig = 1, DateCreated = DateTime.Now, DateEdited = DateTime.Now });
            defaultMovies[1].Post.Comments.Add(new Comment { UserName = "Anon2", Text = "Imo, Worst in the series, yada yada yada 1/5", UserRatig = 1, DateCreated = DateTime.Now, DateEdited = DateTime.Now });
            defaultMovies[2].Post.Comments.Add(new Comment { UserName = "Anon2", Text = "Imo, Worst in the series, yada yada yada 1/5", UserRatig = 1, DateCreated = DateTime.Now, DateEdited = DateTime.Now });

            defaultMovies[0].Post.Comments.Add(new Comment { UserName = "Anon3", Text = "Imo, fully agree with author, yada yada yada 4/5", UserRatig = 5, DateCreated = DateTime.Now, DateEdited = DateTime.Now });
            defaultMovies[1].Post.Comments.Add(new Comment { UserName = "Anon3", Text = "Imo, fully agree with author, yada yada yada 4/5", UserRatig = 5, DateCreated = DateTime.Now, DateEdited = DateTime.Now });
            defaultMovies[2].Post.Comments.Add(new Comment { UserName = "Anon3", Text = "Imo, fully agree with author, yada yada yada 4/5", UserRatig = 5, DateCreated = DateTime.Now, DateEdited = DateTime.Now });

            context.Movie.AddRange(defaultMovies);

            base.Seed(context);
        }
    }
}