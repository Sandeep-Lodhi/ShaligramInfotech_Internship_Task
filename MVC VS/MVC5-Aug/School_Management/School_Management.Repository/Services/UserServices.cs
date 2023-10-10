using School_Management.Helpers.UserHelper;
using School_Management.Models.Context;
using School_Management.Models.Model;
using School_Management.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management.Repository.Services
{
    public class UserServices: IUserInterface
    {
        Ram_School_Management_352Entities dbContext = new Ram_School_Management_352Entities();
        UserHelper us = new UserHelper();

        public bool SignUp(CustomUserPanel data)
        {
            User user = UserHelper.BindCustomUsertoUser(data);
            if(dbContext.User.Any(x => x.Email.ToLower() == data.Email.ToLower() == true))
            {
                return false;

            }
            else
            {
                dbContext.User.Add(user);
                dbContext.SaveChanges();
                return true;
            }
        }

        public string Login(CustomUserPanel data)
        {
            try
            {
                var email = dbContext.User.Where(x => x.Email == data.Email).FirstOrDefault();
                var pass = dbContext.User.Where(x => x.Password == data.Password).FirstOrDefault();

                if (email == null && pass == null)
                {
                    return "Invalid Email & password";
                }
                else if (email != null)
                {
                    if (email.Password != data.Password)
                    {
                        return "Invalid Password";
                    }
                    else
                    {
                        return email.Email;
                    }
                }
                else
                {
                    return "Invalid Email";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //    if(dbContext.User.Any(x => x.Email == data.Email && x.Password == data.Password))
            //    {
            //        return 1;
            //    }
            //    if (!dbContext.User.Any(x => x.Email == data.Email))
            //    {
            //        return 2;
            //    }
            //    if(dbContext.User.Any(x => x.Email == data.Email && x.Password != data.Password))
            //    {
            //        return 3;
            //    }
            //    return 0;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public List<CustomUserPanel> GetAllUserList()
        {
            try
            {
                List<User> user = new List<User>();
                List<CustomUserPanel> customUserPanel = new List<CustomUserPanel>();
                user = dbContext.User.ToList();
                customUserPanel = UserHelper.BindCustomUserListToUserList(user);
                if (customUserPanel != null && customUserPanel.Count > 0)
                {
                    return customUserPanel;
                }
                else
                { 
                return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User DeleteUserRecord(int id)
        {
            var DeleteUser = dbContext.User.Find(id);

            if (DeleteUser != null)
            {
                var Delete = dbContext.User.Remove(DeleteUser);
                dbContext.SaveChanges();
                return Delete;
            }
            else 
            {
                return null;
            }
        }

        public CustomUserPanel EditUserRecord(int id)
        {
            User user;
            user = dbContext.User.Find(id);
            CustomUserPanel customUserPanel = UserHelper.EditUserRecord(user);
            return customUserPanel;
        }

        public int UpdateUserData(CustomUserPanel data)
        {
            try
            {
                User user1 = UserHelper.BindCustomUsertoUser(data);

                dbContext.Entry(user1).State = System.Data.Entity.EntityState.Modified;

                dbContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    
    }
}
