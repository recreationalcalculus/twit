using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twits.Adapters.Interfaces
{
    public interface IFollower
    {
        void AddFollower(int followeeId, int followerId);

        void RemoveFollower(int followeeId, int followerId);
    }
}
