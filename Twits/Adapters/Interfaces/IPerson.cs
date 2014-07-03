using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twits.Models;

namespace Twits.Adapters.Interfaces
{
    public interface IPerson
    {
        PersonVM GetPerson(int id);
        List<PersonVM> GetPeople();
        List<PersonVM> GetFollowers(int id);
        int CreatePerson(string name, string aboutMe, string imgUrl, bool isUser);
        int SetUser(int personId);

    }
}
