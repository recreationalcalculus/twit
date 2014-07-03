using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twits.Adapters.Adapters;
using Twits.Adapters.Interfaces;

namespace Twits.Controllers
{
    public class apiTwitFollowersController : ApiController
    {
        private IPerson _personAdapter;

        public apiTwitFollowersController()
        {
            _personAdapter = new PersonAdapter();
        }
        public IHttpActionResult Get(int id)
        {
            return Ok(_personAdapter.GetFollowers(id));
        }
    }
}
