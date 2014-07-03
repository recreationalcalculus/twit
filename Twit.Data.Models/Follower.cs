using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twit.Data.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public virtual Person Follower { get; set; }
        public int FolloweeId { get; set; }
        public virtual Person Followee { get; set; }
    }
}
