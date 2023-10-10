using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels;
namespace DatabaseConnection
{
    public class HotelManagementRepository
    {

        //Add User
        public int AddUser(UserModel user)
        {
            using (var context = new KrunalDhote351Entities())
            {
                Users2 users = new Users2()  //DataBase Class
                {
                    UserName=user.Name,
                    Email = user.Email,
                    ContactNo=user.Contact,
                    Address=user.Address,
                    UserType=user.UserTypeId,
                    CityId=user.CityId,
                    StateId=user.StateyId,
                    CountryId=user.CountryId,

                };
                context.Users2.Add(users);
                context.SaveChanges();
                return users.UserID;
            }
        }

        //Show All User
        public List<UserModel> GetAllUsers()
        {
            using (var context = new KrunalDhote351Entities())
            {
                var result = context.Users2
                    .Select(x => new UserModel()
                    {
                        Id = x.UserID,
                        Address = x.Address,
                        Email = x.Email,
                        Name = x.UserName,
                        Contact = x.ContactNo,
                        Country = new CountryModel()
                        {
                            Id = x.Country.id,
                            Name = x.Country.CountryName
                        },
                        UserType = new UserTypeModel()
                        {
                            Id = x.UsersType2.UserTypeId,
                            Name = x.UsersType2.UserTypeName
                        },
                        State = new StateModel()
                        {
                            Id = x.State.id,
                            Name = x.State.StateName
                        },
                        City = new CityModel()
                        {
                            Id = x.City.id,
                            Name = x.City.CityName
                        }
                    }).ToList();
                return result;
            }
        }

        //Get One User
        public UserModel GetOneUser(int id)
        {
            using (var context = new KrunalDhote351Entities())
            {
                var result = context.Users2
                    .Where(x=>x.UserID==id)
                    .Select(x => new UserModel()
                    {
                        Id = x.UserID,
                        Address = x.Address,
                        Email = x.Email,
                        Name = x.UserName,
                        Contact = x.ContactNo,
                        Country = new CountryModel()
                        {
                            Id = x.Country.id,
                            Name = x.Country.CountryName
                        },
                        UserType = new UserTypeModel()
                        {
                            Id = x.UsersType2.UserTypeId,
                            Name = x.UsersType2.UserTypeName
                        },
                        State = new StateModel()
                        {
                            Id = x.State.id,
                            Name = x.State.StateName
                        },
                        City = new CityModel()
                        {
                            Id = x.City.id,
                            Name = x.City.CityName
                        }
                    }).FirstOrDefault();
                return result;
            }
        }


        public bool UpdateUser(int id,UserModel user)
        {
            using (var context =new KrunalDhote351Entities())
            {
                var result = context.Users2.FirstOrDefault(x => x.UserID == id);

                if (result != null)
                {
                    result.UserName = user.Name;
                    result.UserType = user.UserTypeId;
                    result.CountryId = user.CountryId;
                    result.StateId = user.StateyId;
                    result.CityId = user.CityId;
                    result.ContactNo = user.Contact;
                    result.Email = user.Email;
                    result.Address = user.Address;

                }
                context.SaveChanges();
                return true;
            }                
        }

        public bool DeleteUser(int id)
        {
            using(var context=new KrunalDhote351Entities())
            {
                var result = context.Users2.FirstOrDefault(x => x.UserID == id);
                if (result != null)
                {
                    context.Users2.Remove(result);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }


    }
}
