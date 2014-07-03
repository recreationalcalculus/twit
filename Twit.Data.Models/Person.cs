using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twit.Data.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string AboutMe { get; set; }
        public string ImgUrl { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
        public bool IsUser { get; set; }

        public Person(string name, string aboutMe, string imgUrl,bool isUser=false)
        {
            Name = name;
            AboutMe = aboutMe;
            ImgUrl = imgUrl;
            Tweets = new List<Tweet>();
            IsUser = isUser;
        }

        public Person()
        {
            Tweets = new List<Tweet>();
        }

        public int CreateTweet(string body)
        {
            Tweet tweet = new Tweet(body, PersonId);
            Tweets.Add(tweet);
            return tweet.TweetId;
        }

        public void DeleteTweet(int id)
        {
            Tweet tweet = Tweets.Where(t => t.TweetId == id).FirstOrDefault();
            tweet.Visible = false;
        }
    }
}
