using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityFramework.Services;

namespace AplicationServices.Services
{
    public class UserService : IUser
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Users> CreateUser(Users user)
        { 
            
            try
            {
                if (user == null)
                    throw new ApplicationException("El usuario no puede ser nulo.");

                if (string.IsNullOrWhiteSpace(user.name))
                    throw new ApplicationException("El nombre del usuario es obligatorio.");

                user.name = user.name.Trim()!.ToUpper();

                var getUsers = await userRepository.GetAll();

                var exist = getUsers.FirstOrDefault(u => u.name == user.name);

                if (exist != null && user.balance > exist.balance)
                {
                    
                    exist.balance =  user.balance + exist.balance;

                    userRepository.Update(exist);
                }
                else
                {
                    if (exist != null )
                    {
                        exist.balance = user.balance;
                        userRepository.Update(exist);
                    }
                    else
                    {
                         await userRepository.Add(user);
                    }
                }
                
               
                await userRepository.Savechanges();
                return exist!;

               
            }
            catch (DbUpdateException msgError)
            {

                throw new ApplicationException($"Error al guardar el usuario, verique bien sus datos", msgError);
            }
            catch(Exception msgError) 
            {
                throw new ApplicationException($"Error inesperado al crear el usuario", msgError);
            }

        }

        public Task<Users?> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ApplicationException($"Debe Digitar un nombre de usuario");

            name = name.Trim().ToUpper()!;

            var getName = userRepository.GetByName(name);

            if(getName != null)
                return getName;
            throw new ApplicationException("Este usuario no fue encontrado");


        }
    }
}
