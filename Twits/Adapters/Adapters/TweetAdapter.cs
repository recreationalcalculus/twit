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
            return db.Tweets.Where(t => t.TweetId == tweetId).Select(t => new TweetVM{
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
    }
}