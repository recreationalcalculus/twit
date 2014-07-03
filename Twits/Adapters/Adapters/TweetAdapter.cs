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
    public class TweetAdapter : ITweet
    {
        
        public TweetVM GetTweet(int tweetId)
        {
            TwitDbContext db = new TwitDbContext();
            return db.Tweets.Where(t => t.TweetId == tweetId && t.Visible).Select(t => new TweetVM{
            Id = t.TweetId,
            Timestamp = t.Timestamp,
            Body = t.Body,
            AuthorName = db.People.Where(p => p.PersonId == t.Twit.PersonId).FirstOrDefault().Name,
            AuthorId = db.People.Where(p => p.PersonId == t.Twit.PersonId).FirstOrDefault().PersonId,
            Visible = t.Visible
            }).FirstOrDefault();
        }

        public List<TweetVM> GetPersonTweets(int personId)
        {
            TwitDbContext db = new TwitDbContext();
            Person person = db.People.Where(p => p.PersonId == personId).FirstOrDefault();
            List<TweetVM> tweets = person.Tweets.Select(t => GetTweet(t.TweetId)).ToList();
            return tweets;
        }
        
        public void DeleteTweet(int deleterId, int tweetId)
        {
            TwitDbContext db = new TwitDbContext();
            Tweet tweet = db.Tweets.Where(t => t.TweetId == tweetId).FirstOrDefault();
            int authorId = tweet.Twit.PersonId;
            if (tweet != null && deleterId == authorId)
            {
                tweet.Visible = false;
            }
            db.SaveChanges();
        }


        public int CreateTweet(int posterId, string body)
        {
            TwitDbContext db = new TwitDbContext();
            db.Tweets.Add(new Tweet(body, posterId));
            db.SaveChanges();
            return db.Tweets.Where(t => t.Body == body).Last().TweetId;
        }
    }
}