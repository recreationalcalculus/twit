using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twit.Data;
using Twit.Data.Models;
using Twits.Adapters.Interfaces;
using Twits.Models;

namespace Twits.Adapters.Adapters
{
    public class PersonAdapter : IPerson
    {
        public PersonVM GetPerson(int id)
        {
            TwitDbContext db = new TwitDbContext();
            return db.People.Where(p => p.PersonId == id).Select(p => new PersonVM
            {
                Id = p.PersonId,

                Name = p.Name,

                ImgUrl = p.ImgUrl,

                AboutMe = p.AboutMe,

                Tweets = p.Tweets.Where(t => t.Visible).Select(
                    t => new TweetVM
                    {
                        Id = t.TweetId,
                        Timestamp = t.Timestamp,
                        Body = t.Body,
                        AuthorId = t.Twit.PersonId,
                        AuthorName = t.Twit.Name,
                    }).ToList(),

                FollowerIds = db.Follows.Where(f => f.FolloweeId == p.PersonId).Select(f => f.FollowerId).ToList()

            }).FirstOrDefault();
        }

        public List<PersonVM> GetPeople()
        {
            TwitDbContext db = new TwitDbContext();
            List<int> Ids = db.People.Select(p => p.PersonId).ToList();
            return Ids.Select(i => GetPerson(i)).ToList();
        }

        public List<PersonVM> GetFollowers(int id)
        {
            TwitDbContext db = new TwitDbContext();
            List<int> followerIds = db.Follows.Where(f => f.FolloweeId == id).Select(p => p.FollowerId).ToList();
            List<PersonVM> followers = followerIds.Select(f => GetPerson(f)).ToList();
            return followers;
        }


        public int CreatePerson(string name, string aboutMe, string imgUrl, bool isUser)
        {
            Person person = new Person(name, aboutMe, imgUrl, isUser);
            TwitDbContext db = new TwitDbContext();
            //check to see if someone else is the user
            if (isUser)
            {
                List<Person> currentUsers = db.People.Where(p => p.IsUser).ToList();
                foreach (var p in currentUsers)
                {
                    p.IsUser = false;
                }
            }
            db.People.Add(person);
            db.SaveChanges();
            return db.People.Last().PersonId;

        }

        public int SetUser(int personId)
        {
            TwitDbContext db = new TwitDbContext();
            //check to see if anyone else is a user
            List<Person> currentUsers = db.People.Where(p => p.IsUser).ToList();
            foreach (var p in currentUsers)
            {
                p.IsUser = false;
            }

            db.People.Where(p => p.PersonId == personId).FirstOrDefault().IsUser = true;
            db.SaveChanges();
            return db.People.Where(p => p.IsUser).FirstOrDefault().PersonId;
        }
    }
}