using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twits.Adapters.Adapters;
using Twits.Adapters.Interfaces;
using Twits.Models;

namespace Twits.Controllers
{
    public class apiTweetController : ApiController
    {
        private ITweet _tweetAdapter;
        public apiTweetController()
        {
            _tweetAdapter = new TweetAdapter();
        }
        public IHttpActionResult Get(int id = -1)
        {
            if (id == -1)
            {
                return Redirect("/TwitApp/error404.html");
            }
            else
            {
                TweetVM tweet = _tweetAdapter.GetTweet(id);
                if (tweet == null)
                {
                    return Redirect("/TwitApp/error404.html");
                }
                else
                {
                    return Ok(tweet);
                }
            }

        }
    }
}
