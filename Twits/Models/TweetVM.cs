using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twits.Models
{
    public class TweetVM
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Body { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public bool Visible { get; set; }
    }
}