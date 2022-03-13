using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ring_120322.Models
{
    public class RingCollection : IRingCollection
    {
        private List<string> _users {get;set;} = new();
        private List<List<string>> _toNotify {get;set;} = new();

        public bool Add(string user)
        {
            if (!_users.Contains(user) && user!=null)
            {
                _users.Add(user);
                return true;
            }
            return false;
        }

        public bool Remove(string user)
        {
            if (_users.Contains(user))
            {
                _users.Remove(user);
                return true;
            }
            return false;
        }

        public bool Notify(string user, string from)
        {
            if (_users.Contains(user) && _users.Contains(from))
            {
                _toNotify.Add(new List<string>(){user, from});
                return true;
            }
            return false;
        }

        public bool Notify(string user, string from, string message)
        {
            if (_users.Contains(user) && _users.Contains(from))
            {
                _toNotify.Add(new List<string>(){user, from, message});
                return true;
            }
            return false;
        }

        public List<string> GetNotifications(string user)
        {
            if (_users.Contains(user))
            {
                foreach (List<string> pair in _toNotify)
                {
                    if (pair[0].Equals(user))
                    {
                        _toNotify.Remove(pair);
                        pair.RemoveAt(0);
                        return pair;
                    }
                }
            }
            return new List<string>();
        }

        public List<string> GetUsers()
        {
            return _users;
        }
    }
}
