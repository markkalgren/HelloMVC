using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class EditPassFM
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string NewPass { get; set; }
        public string ConfirmPass { get; set; }
        public EditPassFM(User user)
        {
            this.ID = user.ID;
            this.Password = user.Password;
            this.NewPass = user.Password;
            this.ConfirmPass = user.Password;
        }
        public EditPassFM()
        {
                
        }
    }
}
