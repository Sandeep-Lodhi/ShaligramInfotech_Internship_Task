using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels;


namespace DatabaseConnection
{
    public class AuthOperationRepo
    {
        public bool LoggedIn(Login login)
        {
            using (var context = new KrunalDhote351Entities())
            {
                var result = context.Authentications.Where(x=>x.UserName==login.username).Select(x=>x.UserName==login.username && x.Password==login.password).FirstOrDefault();
                return result;
            }
        }

        public int Create(CreateAccount create)
        {
            using(var context =new KrunalDhote351Entities())
            {
                Authentication user = new Authentication()
                {
                    UserName = create.UserName,
                    Password=create.password
                };
                context.Authentications.Add(user);
                context.SaveChanges();
                var id = user.UserId;

                User adduser = new User()
                {
                    FirstName=create.fname,
                    LastName=create.lname,
                    email=create.email,
                    MobileNo=create.contact,
                    Addres=create.address,
                    Password="Sit@321#12",
                    UserTypeId=101,
                    CountryId=create.Country.Id,
                    StateId=create.State.Id,
                    CityId=create.City.Id,
                    UserName=id
                };
                context.Users.Add(adduser);
                context.SaveChanges();
                return adduser.id;
            }
        }

        public List<CreateAccount> ShowAllUsers()
        {
            using (var context = new KrunalDhote351Entities())
            {
                var result = context.Users.Select(x => new CreateAccount()
                {
                    id = x.id,
                    fname = x.FirstName,
                    lname = x.LastName,
                    email = x.email,
                    address = x.Addres,
                    UserName = x.Authentication.UserName,
                    Country = new CountryModel()
                    {
                        Id = x.Country.id,
                        Name = x.Country.CountryName
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


        public CreateAccount EditUserDetail(int id)
        {
            using (var context = new KrunalDhote351Entities())
            {
                var result = context.Users.Where(x => x.id == id).Select(x => new CreateAccount()
                {
                    id=x.id,
                    fname=x.FirstName,
                    lname=x.LastName,
                    email=x.email,
                    contact=x.MobileNo,
                    address=x.Addres,
                    password=x.Authentication.Password,
                    UserName=x.Authentication.UserName,
                    Country = new CountryModel()
                    {
                        Id = x.Country.id,
                        Name = x.Country.CountryName
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
    }
}
