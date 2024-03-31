using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Services
{
    public interface IUser_TypesService
    {
        Task<List<User_Types>> GetAll();
        Task<User_Types?> GetUserType(int User_Type_Id);
        Task<User_Types> CreateUserType(string User_Type_Name);
        Task<User_Types?> UpdateUserType(int User_Type_Id, string User_Type_Name);
        Task<User_Types?> DeleteUserType(int User_Type_Id);
    }
    public class User_TypesService : IUser_TypesService
    {
        public readonly IUser_TypesRepository _users_TypesRepository;
        public User_TypesService(User_TypesRepository users_TypesRepository)
        {
            _users_TypesRepository = users_TypesRepository;
        }
        public async Task<User_Types> CreateUserType(string User_Type_Name)
        {
            return await _users_TypesRepository.CreateUserType(User_Type_Name);
        }

        public async Task<User_Types?> DeleteUserType(int User_Type_Id)
        {
            return await _users_TypesRepository.DeleteUserType(User_Type_Id);
        }

        public async Task<List<User_Types>> GetAll()
        {
            return await _users_TypesRepository.GetAll();
        }

        public async Task<User_Types?> GetUserType(int User_Type_Id)
        {
            return await _users_TypesRepository.GetUserType(User_Type_Id);
        }

        public async Task<User_Types?> UpdateUserType(int User_Type_Id, string User_Type_Name = null)
        {
            User_Types? userTypeToUpdate = await _users_TypesRepository.GetUserType(User_Type_Id);

            if (userTypeToUpdate != null)
            {
                if (User_Type_Name == null) { User_Type_Name = userTypeToUpdate.User_Type_Name; }
               
                await _users_TypesRepository.UpdateUserType(User_Type_Id, User_Type_Name);
            }

            return userTypeToUpdate;
        }
    }
}
