using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ring_120322.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ring_120322.Controllers
{
    [Route("/l/")]
    public class LogicController : Controller
    {
        public IRingCollection C;

        public LogicController(IRingCollection c)
        {
            C = c;
        }

        [HttpGet("/l/add/{user}")]
        public ActionResult<bool> AddUser(string user)
        {
            return C.Add(user);
        }

        [HttpGet("/l/remove/{user}")]
        public ActionResult<bool> RemoveUser(string user)
        {
            return C.Remove(user);
        }

        [HttpGet("/l/notify/{user}/{from}")]
        public ActionResult<bool> NotifyUser(string user, string from)
        {
            return C.Notify(user, from);
        }

        [HttpGet("/l/notify/{user}/{from}/{message}")]
        public ActionResult<bool> NotifyUser(string user, string from, string message)
        {
            return C.Notify(user, from, message);
        }

        [HttpGet("/l/notifications/{user}")]
        public ActionResult<List<string>> GetNotifications(string user)
        {
            return C.GetNotifications(user);
        }

        [HttpGet("/l/users")]
        public ActionResult<List<string>> GetUsers()
        {
            return C.GetUsers();
        }
    }
}
