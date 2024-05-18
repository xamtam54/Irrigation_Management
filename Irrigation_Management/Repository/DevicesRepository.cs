using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Repository
{
    public interface IDevicesRepository
    {
        Task<List<Devices>> GetDevices();
        Task<Devices?> GetDevice(int Device_Id);
        Task<Devices> CreateDevice(string Device_Name, decimal Device_Price, int Device_Enabled, int System_Id, int? Area_Id);
        Task<Devices?> UpdateDevice(int Device_Id, string Device_Name, decimal Device_Price, int Device_Enabled, int System_Id, int? Area_Id);
        Task<Devices?> DeleteDevice(Devices deviceToDelete);
    }
    public class DevicesRepository : IDevicesRepository
    {
        private readonly ManagementDBContext _db;
        public DevicesRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<Devices> CreateDevice(string Device_Name, decimal Device_Price, int Device_Enabled, int System_Id, int? Area_Id)
        {
            Devices newDevice = new Devices
            {
                Device_Name = Device_Name,
                Device_Price = Device_Price,
                Device_Enabled = Device_Enabled,
                System_Id = System_Id,
                Area_Id = Area_Id,
            };

            await _db.Devices.AddAsync(newDevice);
            _db.SaveChanges();
            return newDevice;
        }

        public async Task<Devices?> DeleteDevice(Devices deviceToDelete)
        {
            if (deviceToDelete != null)
            {
                deviceToDelete.IsDeleted = true; 
                await _db.SaveChangesAsync();
            }

            return deviceToDelete;
        }

        public async Task<Devices?> GetDevice(int Device_Id)
        {
            return await _db.Devices.FindAsync(Device_Id);
        }

        public async Task<List<Devices>> GetDevices()
        {
            return await _db.Devices.Where(u => u.IsDeleted == false).ToListAsync();
        }

        public async Task<Devices?> UpdateDevice(int Device_Id, string Device_Name, decimal Device_Price, int Device_Enabled, int System_Id, int? Area_Id)
        {
            Devices? deviceToUpdate = await GetDevice(Device_Id);

            if (deviceToUpdate != null)
            {
                deviceToUpdate.Device_Name = Device_Name;
                deviceToUpdate.Device_Price = Device_Price;
                deviceToUpdate.Device_Enabled = Device_Enabled;
                deviceToUpdate.System_Id = System_Id;
                deviceToUpdate.Area_Id = Area_Id;

                await _db.SaveChangesAsync();
            }

            return deviceToUpdate;
        }
    }
}
