using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace AplicationServices.Services
{
    public interface IUser
    {

        Task<Users?> GetByName(string name);

        Task<Users> CreateUser(Users user);

    }
}
