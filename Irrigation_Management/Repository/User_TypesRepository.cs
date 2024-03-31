using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Repository
{
    public interface IUser_TypesRepository
    {
        Task<List<User_Types>> GetAll();
        Task<User_Types?> GetUserType(int User_Type_Id);
        Task<User_Types> CreateUserType(string User_Type_Name);
        Task<User_Types?> UpdateUserType(int User_Type_Id, string User_Type_Name);
        Task<User_Types?> DeleteUserType(int User_Type_Id);
    }
    public class User_TypesRepository : IUser_TypesRepository
    {
        private readonly ManagementDBContext _db;
        public User_TypesRepository(ManagementDBContext db)
        {
            _db = db;
        }
        public async Task<User_Types> CreateUserType(string User_Type_Name)
        {
            User_Types newUserType = new User_Types
            {
                User_Type_Name = User_Type_Name,
            };

            await _db.User_Types.AddAsync(newUserType);
            _db.SaveChanges();
            return newUserType;
        }

        public async Task<User_Types?> DeleteUserType(int User_Type_Id)
        {
            User_Types? userTypeToDelete = await GetUserType(User_Type_Id);

            if (userTypeToDelete != null)
            {
                _db.User_Types.Remove(userTypeToDelete);
                await _db.SaveChangesAsync();
            }

            return userTypeToDelete;
        }

        public async Task<List<User_Types>> GetAll()
        {
            return await _db.User_Types.ToListAsync();
        }

        public async Task<User_Types?> GetUserType(int User_Type_Id)
        {
            return await _db.User_Types.FindAsync(User_Type_Id);
        }

        public async Task<User_Types?> UpdateUserType(int User_Type_Id, string User_Type_Name)
        {
            User_Types? userTypeToUpdate = await GetUserType(User_Type_Id);

            if (userTypeToUpdate != null)
            {
                userTypeToUpdate.User_Type_Name = User_Type_Name;
                
                await _db.SaveChangesAsync();
            }

            return userTypeToUpdate;
        }
    }
}
