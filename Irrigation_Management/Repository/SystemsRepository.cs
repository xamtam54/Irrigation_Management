using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Repository
{
    public interface ISystemsRepository
    {
        Task<List<Systems>> GetSystems();
        Task<Systems?> GetSystem(int System_Id);
        Task<Systems> CreateSystem(string Systems_Name);
        Task<Systems?> UpdateSystem(int System_Id, string Systems_Name);
        Task<Systems?> DeleteSystem(Systems systemToDelete);
    }
    public class SystemsRepository : ISystemsRepository
    {
        private readonly ManagementDBContext _db;
        public SystemsRepository(ManagementDBContext db)
        {
            _db = db;
        }
        public async Task<Systems> CreateSystem(string Systems_Name)
        {
            Systems newSystem = new Systems
            {
                Systems_Name = Systems_Name,
            };

            await _db.Systems.AddAsync(newSystem);
            _db.SaveChanges();
            return newSystem;
        }

        public async Task<Systems?> DeleteSystem(Systems systemToDelete)
        {
            if (systemToDelete != null)
            {
                systemToDelete.IsDeleted = true;
                await _db.SaveChangesAsync();
            }

            return systemToDelete;
        }

        public async Task<Systems?> GetSystem(int System_Id)
        {
            return await _db.Systems.FindAsync(System_Id);
        }

        public async Task<List<Systems>> GetSystems()
        {
            return await _db.Systems.ToListAsync();
        }

        public async Task<Systems?> UpdateSystem(int System_Id, string Systems_Name)
        {
            Systems? systemToUpdate = await GetSystem(System_Id);

            if (systemToUpdate != null)
            {
                systemToUpdate.Systems_Name = Systems_Name;

                await _db.SaveChangesAsync();
            }
            return systemToUpdate;
        }
    }
}
