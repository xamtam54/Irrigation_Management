using Irrigation_Management.Models;
using Irrigation_Management.Repository;

namespace Irrigation_Management.Services
{
    public interface IUsersService
    {
        Task<List<Users>> GetAll();
        Task<Users?> GetUser(int User_Id);
        Task<Users> CreateUser(string UserName, string Names, string Surnames, string Password, string Email, int User_Type_Id);
        Task<Users?> UpdateUser(int User_Id, string? UserName, string? Names, string? Surnames, string? Password, string? Email, int? Is_Active, int? User_Type_Id);
        Task<Users?> DeleteUser(int User_Id);
        //-----------------------------------------------------------------------
        Task<Allocation_Systems> CreateAllocationSystem(int? gameId = -1, int systemId = -1, int userId = -1);
        Task<Allocation_Systems?> DeleteAllocationSystem(int? gameId = -1, int systemId = -1, int userId = -1);
    }

    public class UsersService : IUsersService
    {
        public readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<Users> CreateUser(string UserName, string Names, string Surnames, string Password, string Email, int User_Type_Id)
        {
            return await _usersRepository.CreateUser(UserName, Names, Surnames, Password, Email, User_Type_Id);
        }

        public async Task<Users?> DeleteUser(int User_Id)
        {
            Users? user = await _usersRepository.GetUser(User_Id);

            if (user != null)
            {
                user.IsDeleted = true;
                //user.date = DateTime.Now;
                return await _usersRepository.DeleteUser(user);
            }
            
            return null;
        }
       

        public async Task<List<Users>> GetAll()
        {
            return await _usersRepository.GetAll();
        }

        public async Task<Users?> GetUser(int User_Id)
        {
            return await _usersRepository.GetUser(User_Id);
        }

        public async Task<Users?> UpdateUser(int Users_Id, string? UserName = null, string? Names = null, string? Surnames = null, string? Password = null, string? Email = null, int? Is_Active = -1, int? User_Type_Id = -1)
        {
            Users? userToUpdate = await _usersRepository.GetUser(Users_Id);

            if (userToUpdate != null)
            {
                if (UserName == null) { UserName = userToUpdate.UserName; }
                if (Names == null) { Names = userToUpdate.Names; }
                if (Surnames == null) { Surnames = userToUpdate.Surnames; }
                if (Password == null) { Password = userToUpdate.Password; }
                if (Email == null) { Email = userToUpdate.Email; }
                if (Is_Active == -1) { Is_Active = userToUpdate.Is_Active; }
                if (User_Type_Id == -1) { User_Type_Id = userToUpdate.User_Type_Id; }

                await _usersRepository.UpdateUser(Users_Id, UserName, Names, Surnames, Password, Email, (int)Is_Active, (int)User_Type_Id);
            }
            
            return userToUpdate; 

        }

        //-------------------------------------------------------------------------------------------
        public async Task<Allocation_Systems> CreateAllocationSystem(int? gameId, int systemId, int userId)
        {
            return await _usersRepository.CreateAllocationSystem(gameId, systemId, userId);
        }

        public async Task<Allocation_Systems?> DeleteAllocationSystem(int? gameId, int systemId, int userId)
        {
            return await _usersRepository.DeleteAllocationSystem(gameId, systemId, userId);
        }

    }
}
