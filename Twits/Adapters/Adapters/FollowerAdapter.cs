using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twit.Data;
using Twit.Data.Models;
using Twits.Adapters.Interfaces;
using Twits.Models;

namespace Twits.Adapters.Adapters
{
    public class FollowerAdapter : IFollower
    {
        public void AddFollower(int followeeId, int followerId)
        {
            TwitDbContext db = new TwitDbContext();
            if (db.Follows.Where(f => f.FolloweeId == followeeId && f.FollowerId == followerId).FirstOrDefault() != null)
            {
                db.Follows.Add(new Follow { FolloweeId = followeeId, FollowerId = followerId });
            }
            db.SaveChanges();

        }

        public void RemoveFollower(int followeeId, int followerId)
        {
            TwitDbContext db = new TwitDbContext();
            int id = db.Follows.Where(f => f.FolloweeId == followeeId && f.FollowerId == followerId).FirstOrDefault().Id;
            db.Follows.Remove(db.Follows.Where(f => f.Id == id).FirstOrDefault());
            db.SaveChanges();
        }
    }
}