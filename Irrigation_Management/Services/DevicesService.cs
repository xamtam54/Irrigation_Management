using Irrigation_Management.Models;
using Irrigation_Management.Repository;
using static Azure.Core.HttpHeader;

namespace Irrigation_Management.Services
{
    public interface IDevicesService
    {
        Task<List<Devices>> GetDevices();
        Task<Devices?> GetDevice(int Device_Id);
        Task<Devices> CreateDevice(string Device_Name, decimal Device_Price, int Device_Enabled, int System_Id, int? Area_Id);
        Task<Devices?> UpdateDevice(int Device_Id, string? Device_Name, decimal? Device_Price, int? Device_Enabled, int? System_Id, int? Area_Id);
        Task<Devices?> DeleteDevice(int Device_Id);
    }
    public class DevicesService : IDevicesService
    {
        public readonly IDevicesRepository _devicesRepository;
        public DevicesService(IDevicesRepository devicesRepository)
        {
            _devicesRepository = devicesRepository;
        }

        public async Task<Devices> CreateDevice(string Device_Name, decimal Device_Price, int Device_Enabled, int System_Id, int? Area_Id)
        {
            return await _devicesRepository.CreateDevice(Device_Name, Device_Price, Device_Enabled, System_Id, Area_Id);
        }

        public async Task<Devices?> DeleteDevice(int Device_Id)
        {
            Devices? device = await _devicesRepository.GetDevice(Device_Id);

            if (device != null)
            {
                device.IsDeleted = true;
                // device.Date = DateTime.Now;
                return await _devicesRepository.DeleteDevice(device);
            }

            return null;
        }


        public async Task<Devices?> GetDevice(int Device_Id)
        {
            return await _devicesRepository.GetDevice(Device_Id);
        }

        public async Task<List<Devices>> GetDevices()
        {
            return await _devicesRepository.GetDevices();
        }

        public async Task<Devices?> UpdateDevice(int Device_Id, string? Device_Name, decimal? Device_Price = -1, int? Device_Enabled =  -1, int? System_Id = -1, int? Area_Id = -1)
        {
            Devices? deviceToUpdate = await _devicesRepository.GetDevice(Device_Id);

            if (deviceToUpdate != null)
            {
                if (Device_Name == null) { Device_Name = deviceToUpdate.Device_Name; }
                if (Device_Price == -1) { Device_Price = deviceToUpdate.Device_Price; }
                if (Device_Enabled == -1) { Device_Enabled = deviceToUpdate.Device_Enabled; }
                if (System_Id == -1) { System_Id = deviceToUpdate.System_Id; }
                if (Area_Id == -1) { Area_Id = deviceToUpdate.Area_Id; }


                await _devicesRepository.UpdateDevice(Device_Id, Device_Name, (decimal)Device_Price, (int)Device_Enabled, (int)System_Id, Area_Id);
            }

            return deviceToUpdate;
        }
    }
}
