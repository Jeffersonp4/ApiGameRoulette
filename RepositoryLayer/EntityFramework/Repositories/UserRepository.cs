using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.EntityFramework.Services;

namespace RepositoryLayer.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<Users>,IUserRepository
    {
        private readonly RouletteDbContext dbContext;
        public UserRepository(RouletteDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Users?> GetByName(string name)
        {
            try
            {
                return await dbContext.Users.Where(u => u.name == name).FirstOrDefaultAsync();

            }
            catch (Exception msgError)
            {

                throw new NpgsqlException ($"Ha ocurrido un error buscando el nombre{msgError}");
            }
        }
    }
}
