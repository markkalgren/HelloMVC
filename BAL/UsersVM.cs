using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class UsersVM
    {
        public List<UserVM> Users { get; set; }
        public UsersVM()
        {
            Users = new List<UserVM>();
        }
    }
}
