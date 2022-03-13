using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ring_120322.Models
{
    public interface IRingCollection
    {
        public bool Add(string user);

        public bool Remove(string user);

        public bool Notify(string user, string from);

        public bool Notify(string user, string from, string message);

        public List<string> GetNotifications(string user);

        public List<string> GetUsers();
    }
}
