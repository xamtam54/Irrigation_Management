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
        Task<Users?> DeleteUser(int User_Id);

        //-------------------------------------------------------------
        Task<Allocation_Achievements> CreateAllocation(int userId, int achievementId);
        Task<Allocation_Achievements?> DeleteAllocation(int userId, int achievementId);
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


        public async Task<Users?> DeleteUser(int User_Id)
        {
            Users? userToDelete = await GetUser(User_Id);

            if (userToDelete != null)
            {
                _db.Users.Remove(userToDelete);
                await _db.SaveChangesAsync();
            }

            return userToDelete;
        }

        //----------------------------------------------------------------------------
        public async Task<Allocation_Achievements> CreateAllocation(int userId, int achievementId)
        {
            var existingAllocation = await _db.Allocation_Achievements
                .SingleOrDefaultAsync(a => a.Users_Id == userId && a.Achievement_Id == achievementId);

            if (existingAllocation != null)
            {
                throw new InvalidOperationException("already exists");
            }

            var user = await _db.Users.FindAsync(userId);
            var achievement = await _db.Achievements.FindAsync(achievementId);

            if (user == null || achievement == null)
            {
                throw new InvalidOperationException("User or achievement does not exist");
            }

            var allocation = new Allocation_Achievements
            {
                Users_Id = userId,
                Achievement_Id = achievementId
            };

            await _db.Allocation_Achievements.AddAsync(allocation);
            await _db.SaveChangesAsync();

            return allocation;
        }

        public async Task<Allocation_Achievements?> DeleteAllocation(int userId, int achievementId)
        {
            var allocation = await _db.Allocation_Achievements
                .SingleOrDefaultAsync(a => a.Users_Id == userId && a.Achievement_Id == achievementId);

            if (allocation != null)
            {
                _db.Allocation_Achievements.Remove(allocation);
                await _db.SaveChangesAsync();
            }

            return allocation;
        }
    }
}