using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.EntityFramework.Services;

namespace RepositoryLayer.EntityFramework.Repositories
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        private readonly RouletteDbContext _dbContext;
        private readonly DbSet<T> _DbSet;

        public BaseRepository(RouletteDbContext dbContext)
        {
            _dbContext = dbContext;
            _DbSet = dbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            try
            {
                await  _DbSet.AddAsync(entity);

            }
            catch (Exception msgError)
            {

                throw new NpgsqlException ($"Ha ocurrido un error al guardar en base de datos{msgError}");
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task Savechanges()
        {

            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            try
            {
                _dbContext.Update(entity);

            }
            catch (Exception msgError)
            {

                throw new NpgsqlException($"Ha ocurrido un error al guardar en base de datos{msgError}");
            }

           
        }
    }
}
