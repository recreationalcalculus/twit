using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twits.Models
{
    public class PersonVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string AboutMe { get; set; }
        public List<TweetVM> Tweets { get; set; }
        public List<int> FollowerIds { get; set; }
        public List<int> FollowingIds { get; set; }
    }
}