using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twits.Models;

namespace Twits.Adapters.Interfaces
{
    public interface ITweet
    {
        TweetVM GetTweet(int tweetId);

        List<TweetVM> GetPersonTweets(int personId);

        int CreateTweet(int posterId, string body);

        void DeleteTweet(int deleterId, int tweetId);

    }
}
