using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserService
    {
        public UsersVM GetUsers()
        {
            UserDAO dao = new UserDAO();
            List<User> users = dao.GetAllUsers();
            UsersVM userList = new UsersVM();
            foreach (User user in users)
            {
                UserVM userVM = new UserVM();
                userVM.ID = user.ID;
                userVM.Email = user.Email;
                userList.Users.Add(userVM);
            }
            return userList;
        }
        //public User ConvertUser(UserFM userFM)
        //{
        //    User user = new User();
        //    user.Email = userFM.Email;
        //    user.Password = null;
        //    return user;
        //}
        public bool CreateUser(UserFM userFM)
        {
            if (IsValidUser(userFM))
            {
                UserDAO dao = new UserDAO();
                User user = new User();
                user.Email = userFM.Email;
                user.Password = GeneratePassword();
                //TODO email temporary password to user
                dao.CreateUser(user); //creating user
                return true;
            }
            return false;
        }
        private string GeneratePassword()
        {
            string password = "";
            Random rng = new Random();
            for (int i = 0; i < 8; i++)
            {
                int cases = rng.Next(1, 4);
                switch (cases)
                {
                    case 1://uppercase
                        password = password + Convert.ToChar(rng.Next(65, 91));
                        break;
                    case 2://number
                        password = password + Convert.ToChar(rng.Next(48, 58));
                        break;
                    case 3://lowercase
                        password = password + Convert.ToChar(rng.Next(97, 123));
                        break;
                }
            }
            return password;
        }
        public bool IsValidUser(UserFM userFM)
        {
            UserDAO dao = new UserDAO();
            if (userFM.Email != null && userFM.Email.Length > 5 && dao.GetUserByEmail(userFM.Email) == null)
            {
                return true;
            }
            return false;
        }

        public UserFM GetUserFM(int ID)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(ID);
            UserFM userFM = new UserFM();
            return userFM;
        }
        public PasswordFM GetPasswordFM(int ID)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(ID);
            PasswordFM passFM = new PasswordFM();
            return passFM;
        }

        public void UpdateUser(UserFM userFM)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(userFM.ID);
            user.Email = userFM.Email;
            dao.UpdateUser(user);
        }

        public void DeleteUser(int ID)
        {
            UserDAO dao = new UserDAO();
            dao.DeleteUser(ID);
        }

        public void EditPassword(PasswordFM passwordFM)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(passwordFM.ID);
            //user.ID = passwordFM.ID;
            user.Password = passwordFM.Password;
            dao.UpdateUser(user);
        }
        public void ResetPassword(int ID)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(ID);
            //user.ID = passwordFM.ID;
            user.Password = GeneratePassword();
            dao.UpdateUser(user);
        }
    }
}
