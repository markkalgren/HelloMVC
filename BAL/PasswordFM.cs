using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class PasswordFM
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public PasswordFM(User user)
        {
            this.Password = user.Password;
            this.ID = user.ID;
        }
        public PasswordFM()
        {

        }
    }
}
