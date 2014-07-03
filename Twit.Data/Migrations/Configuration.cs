namespace Twit.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Twit.Data.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Twit.Data.TwitDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Twit.Data.TwitDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //context.People.Add(new Person("Bob", "About Bob", "http://www.Lorempixel.com/300/300"));
            //context.SaveChanges();

            //Person bob = context.People.Where(p => p.Name == "Bob").FirstOrDefault();
            //bob.CreateTweet("Bob's first tweet.");
            //bob.CreateTweet("Bob's second tweet.");
            //bob.CreateTweet("Bob's third tweet.");
            //context.SaveChanges();

            //context.People.Add(new Person("Tom", "About Tom", "http://www.Lorempixel.com/300/300"));
            //context.SaveChanges();

            //Person tom = context.People.Where(p => p.Name == "Tom").FirstOrDefault();
            //tom.CreateTweet("Tom's first tweet.");
            //tom.CreateTweet("Tom's second tweet.");
            //tom.CreateTweet("Tom's third tweet.");
            //context.SaveChanges();

            //context.People.Add(new Person("Sue", "About Sue", "http://www.Lorempixel.com/300/300"));
            //context.SaveChanges();

            //Person sue = context.People.Where(p => p.Name == "Sue").FirstOrDefault();
            //sue.CreateTweet("Sue's first tweet.");
            //sue.CreateTweet("Sue's second tweet.");
            //sue.CreateTweet("Sue's third tweet.");
            //context.SaveChanges();

            //context.People.Add(new Person("Jon", "About Jon", "http://www.Lorempixel.com/300/300"));
            //context.SaveChanges();

            //Person jon = context.People.Where(p => p.Name == "Jon").FirstOrDefault();
            //jon.CreateTweet("Jon's first tweet.");
            //jon.CreateTweet("Jon's second tweet.");
            //jon.CreateTweet("Jon's third tweet.");
            //context.SaveChanges();

            //context.People.Add(new Person("Tod", "About Tod", "http://www.Lorempixel.com/300/300"));
            //context.SaveChanges();

            //Person tod = context.People.Where(p => p.Name == "Tod").FirstOrDefault();
            //tod.CreateTweet("Tod's first tweet.");
            //tod.CreateTweet("Tod's second tweet.");
            //tod.CreateTweet("Tod's third tweet.");
            //context.SaveChanges();

            //context.People.Add(new Person("Sam", "About Sam", "http://www.Lorempixel.com/300/300"));
            //context.SaveChanges();

            //Person sam = context.People.Where(p => p.Name == "Sam").FirstOrDefault();
            //sam.CreateTweet("Sam's first tweet.");
            //sam.CreateTweet("Sam's second tweet.");
            //sam.CreateTweet("Sam's third tweet.");
            //context.SaveChanges();

            //context.Follows.Add(new Follow { FolloweeId = bob.PersonId, FollowerId = tom.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = bob.PersonId, FollowerId = tod.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = bob.PersonId, FollowerId = sue.PersonId });

            //context.Follows.Add(new Follow { FolloweeId = tom.PersonId, FollowerId = bob.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = tom.PersonId, FollowerId = sue.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = tom.PersonId, FollowerId = tod.PersonId });

            //context.Follows.Add(new Follow { FolloweeId = sue.PersonId, FollowerId = tom.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = sue.PersonId, FollowerId = tod.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = sue.PersonId, FollowerId = sam.PersonId });

            //context.Follows.Add(new Follow { FolloweeId = tod.PersonId, FollowerId = sue.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = tod.PersonId, FollowerId = sam.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = tod.PersonId, FollowerId = jon.PersonId });

            //context.Follows.Add(new Follow { FolloweeId = sam.PersonId, FollowerId = tom.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = sam.PersonId, FollowerId = tod.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = sam.PersonId, FollowerId = jon.PersonId });

            //context.Follows.Add(new Follow { FolloweeId = jon.PersonId, FollowerId = sue.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = jon.PersonId, FollowerId = tod.PersonId });
            //context.Follows.Add(new Follow { FolloweeId = jon.PersonId, FollowerId = sam.PersonId });

            //context.SaveChanges();


        }
    }
}
