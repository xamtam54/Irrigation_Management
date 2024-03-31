using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Services
{
    public interface ISystemsService
    {
        Task<List<Systems>> GetSystems();
        Task<Systems?> GetSystem(int System_Id);
        Task<Systems> CreateSystem(string Systems_Name);
        Task<Systems?> UpdateSystem(int System_Id, string Systems_Name);
        Task<Systems?> DeleteSystem(int System_Id);
    }
    public class SystemsService : ISystemsService
    {
        public readonly ISystemsRepository _systemRepository;
        public SystemsService(SystemsRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }
        public async Task<Systems> CreateSystem(string Systems_Name)
        {
            return await _systemRepository.CreateSystem(Systems_Name);
        }

        public async Task<Systems?> DeleteSystem(int System_Id)
        {
            return await _systemRepository.DeleteSystem(System_Id);
        }

        public async Task<Systems?> GetSystem(int System_Id)
        {
            return await _systemRepository.GetSystem(System_Id);
        }

        public async Task<List<Systems>> GetSystems()
        {
            return await _systemRepository.GetSystems();
        }

        public async Task<Systems?> UpdateSystem(int System_Id, string Systems_Name)
        {
            Systems? systemToUpdate = await _systemRepository.GetSystem(System_Id);

            if (systemToUpdate != null)
            {
                if (Systems_Name == null) { Systems_Name = systemToUpdate.Systems_Name; }

                await _systemRepository.UpdateSystem(System_Id, Systems_Name);
            }

            return systemToUpdate;
        }
    }
}
