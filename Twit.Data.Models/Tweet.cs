using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twit.Data.Models
{
    public class Tweet
    {
        [Key]
        public int TweetId { get; set; }
        public DateTime Timestamp { get; set; }
        private string _body;
        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                if (_body == null) _body = value.Substring(0, Math.Min(144,value.Length));
            }
        }
        public int PersonId { get; set; }
        public bool Visible { get; set; }
        public virtual Person Twit { get; set; }
        public Tweet(string body, int twitId)
        {
            Body = body;
            Timestamp = DateTime.Now;
            PersonId = twitId;
            Visible = true;

        }

        public Tweet()
        {
            Timestamp = DateTime.Now;
            Visible = true;
        }

    }
}
