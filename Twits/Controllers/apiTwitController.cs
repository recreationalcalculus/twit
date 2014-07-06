using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Twit.Data;
using Twit.Data.Models;
using Twits.Adapters.Adapters;
using Twits.Adapters.Interfaces;
using Twits.Models;

namespace Twits.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class apiTwitController : ApiController
    {
        private IPerson _personAdapter;
        private ITweet _tweetAdapter;
        public apiTwitController()
        {
            _personAdapter = new PersonAdapter();
            _tweetAdapter = new TweetAdapter();
        }
        public IHttpActionResult Get(int id = -1)
        {
            if (id == -1)
            {
                return Ok(_personAdapter.GetPeople());
            }
            else
            {
                PersonVM person = _personAdapter.GetPerson(id);
                if (person == null)
                {
                    return Redirect(new Uri("../TwitApp/error.html", UriKind.Relative));
                }
                else
                {
                    return Ok(person);
                }
            }

        }

        [HttpPost]
        public IHttpActionResult Post(string body, int id)
        {
            int tweetId = _tweetAdapter.CreateTweet(id, body);
            return Ok(tweetId);
        }
    }
}
