using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace RepositoryLayer.EntityFramework.Services
{
    public interface IUserRepository:IBaseRepository<Users>
    {

        Task<Users?> GetByName(string name);
    }
}
