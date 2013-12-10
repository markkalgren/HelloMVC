﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAO
    {
        public void Write(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=HelloMVC;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<User> ReadUsers(string statement, SqlParameter[] parameters)
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=HelloMVC;Integrated Security=SSPI;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(statement, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        SqlDataReader data = command.ExecuteReader();
                        List<User> users = new List<User>();
                        while (data.Read())
                        {
                            User user = new User();
                            user.ID = Convert.ToInt32(data["ID"]);
                            user.Email = data["Email"].ToString();
                            user.Password = data["Password"].ToString();
                            users.Add(user);
                        }
                        return users;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error\n" + e.Message);
                Console.ReadKey();
                return null;
            }
        }
        public User GetUserByID(int ID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", ID)
            };
                return ReadUsers("GetUserByID", parameters).SingleOrDefault();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error:\n" + e.Message);
                Console.ReadKey();
                return null;
            }
        }
        public User GetUserByEmail(string email)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", email)
            };
                return ReadUsers("GetUserByEmail", parameters).SingleOrDefault();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: \n" + e.Message);
                Console.ReadKey();
                return null;
            }
        }
        public void CreateUser(User user)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password)
            };
                Write("CreateUser", parameters);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: \n" + e.Message);
                Console.ReadKey();
            }
        }
        public void UpdateUser(User user)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", user.ID),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password)
            };
                Write("UpdateUser", parameters);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: \n" + e.Message);
                Console.ReadKey();
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                return ReadUsers("GetAllUsers", null);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: \n" + e.Message);
                Console.ReadKey();
                return null;
            }
        }
    }
}