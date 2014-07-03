using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twit.Data;
using Twit.Data.Models;
using Twits.Adapters.Adapters;
using Twits.Adapters.Interfaces;
using Twits.Models;

namespace Twits.Controllers
{
    public class apiTwitController : ApiController
    {
        private IPerson _personAdapter;
        public apiTwitController()
        {
            _personAdapter = new PersonAdapter();
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
                    return Redirect("/TwitApp/error404.html");
                }
                else
                {
                    return Ok(person);
                }
            }

        }
    }
}
