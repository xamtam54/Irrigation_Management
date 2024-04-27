using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Irrigation_Management.Services;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAll();
        Task<Users?> GetUser(int User_Id); 
        Task<Users> CreateUser(string UserName, string Names, string Surnames, string Password, string Email, int User_Type_Id);
        Task<Users?> UpdateUser(int Users_Id, string UserName, string Names, string Surnames, string Password, string Email, int Is_Active, int User_Type_Id);
        Task<Users?> DeleteUser(Users user);

        //-------------------------------------------------------------
        //----------------------------------------------------------
        Task<Allocation_Systems> CreateAllocationSystem(int? gameId = -1, int systemId = -1, int userId = -1);
        Task<Allocation_Systems?> DeleteAllocationSystem(int? gameId = -1, int systemId = -1, int userId = -1);
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly ManagementDBContext _db;
        public UsersRepository(ManagementDBContext db)
        {
            _db = db;
        }
        public async Task<List<Users>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<Users?> GetUser(int User_Id)
        {
            return await _db.Users.FindAsync(User_Id);
        }

        public async Task<Users> CreateUser(string UserName, string Names, string Surnames, string Password, string Email, int User_Type_Id)
        {
            Users newUser = new Users
            {
                UserName = UserName,
                Names = Names,
                Surnames = Surnames,
                Password = Password,
                Email = Email,
                User_Type_Id = User_Type_Id
            };

            await _db.Users.AddAsync(newUser);
            _db.SaveChanges();
            return newUser;
        }

        public async Task<Users?> UpdateUser(int Users_Id, string UserName, string Names, string Surnames, string Password, string Email, int Is_Active, int User_Type_Id)
        {
            Users? userToUpdate = await GetUser(Users_Id);

            if (userToUpdate != null)
            {
                userToUpdate.UserName = UserName;
                userToUpdate.Names = Names;
                userToUpdate.Surnames = Surnames;
                userToUpdate.Password = Password;
                userToUpdate.Email = Email;
                userToUpdate.Is_Active = Is_Active;
                userToUpdate.User_Type_Id = User_Type_Id;

                await _db.SaveChangesAsync();
            }

            return userToUpdate;
        }


        public async Task<Users?> DeleteUser(Users userToDelete)
        {

            if (userToDelete != null)
            {
                userToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return userToDelete;
        }

        //--------------------------------------------------------------------------------------------

        public async Task<Allocation_Systems> CreateAllocationSystem(int? gameId = -1, int systemId = -1, int userId = -1)
        {
            var system = await _db.Systems.FindAsync(systemId);
            var game = await _db.Games.FindAsync(gameId);
            var user = await _db.Users.FindAsync(userId);


            if (system != null && user != null)
            {
                var existingAllocation = await _db.Allocation_Systems.FirstOrDefaultAsync(a => a.Game_Id == gameId && a.System_Id == systemId && a.User_Id == userId);
                if (existingAllocation != null)
                {
                    throw new InvalidOperationException("An allocation system for this game and system already exists.");
                }

                var allocationSystem = new Allocation_Systems
                {
                    Game_Id = gameId,
                    System_Id = systemId,
                    User_Id = userId
                };

                await _db.Allocation_Systems.AddAsync(allocationSystem);
                await _db.SaveChangesAsync();
                return allocationSystem;
            }
            else
            {
                throw new InvalidOperationException("does not exist");
            }

        }

        public async Task<Allocation_Systems?> DeleteAllocationSystem(int? gameId = -1, int systemId = -1, int userId = -1)
        {
            var allocationSystem = await _db.Allocation_Systems.FirstOrDefaultAsync(a => a.Game_Id == gameId && a.System_Id == systemId && a.User_Id == userId);

            if (allocationSystem != null)
            {
                _db.Allocation_Systems.Remove(allocationSystem);
                await _db.SaveChangesAsync();
            }

            return allocationSystem;
        }
    }
}