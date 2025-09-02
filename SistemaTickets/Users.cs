using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTickets
{
    internal class Users
    {
        public string UserName { get; set; }

        public Users(string username)
        {
            UserName = username;
        }

        public Users()
        {

        }

    }
}
