﻿using Irrigation_Management.Context;
using Irrigation_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Irrigation_Management.Repository
{
    public interface ISensorDataRepository
    {
        Task<List<Sensor_Data>> GetAll();
        Task<Sensor_Data?> GetSensorData(int Sensor_Data_Id);
        Task<Sensor_Data> CreateSensorData(DateTime Date_Time, float Data, int Sensor_Id);
        Task<Sensor_Data?> UpdateSensorData(int Sensor_Data_Id, DateTime Date_Time, float Data, int Sensor_Id);
        Task<Sensor_Data?> DeleteSensorData(int Sensor_Data_Id);
    }

    public class SensorDataRepository : ISensorDataRepository
    {
        private readonly ManagementDBContext _db;
        public SensorDataRepository(ManagementDBContext db)
        {
            _db = db;
        }

        public async Task<List<Sensor_Data>> GetAll()
        {
            return await _db.Sensor_Data.ToListAsync();
        }

        public async Task<Sensor_Data?> GetSensorData(int Sensor_Data_Id)
        {
            return await _db.Sensor_Data.FindAsync(Sensor_Data_Id);
        }

        public async Task<Sensor_Data> CreateSensorData(DateTime Date_Time, float Data, int Sensor_Id)
        {
            Sensor_Data newData = new Sensor_Data
            {
                Date_Time = Date_Time,
                Data = Data,
                Sensor_Id = Sensor_Id
            };

            await _db.Sensor_Data.AddAsync(newData);
            await _db.SaveChangesAsync();
            return newData;
        }

        public async Task<Sensor_Data?> UpdateSensorData(int Sensor_Data_Id, DateTime Date_Time, float Data, int Sensor_Id)
        {
            Sensor_Data? dataToUpdate = await GetSensorData(Sensor_Data_Id);

            if (dataToUpdate != null)
            {
                dataToUpdate.Date_Time = Date_Time;
                dataToUpdate.Data = Data;
                dataToUpdate.Sensor_Id = Sensor_Id;

                await _db.SaveChangesAsync();
            }

            return dataToUpdate;
        }

        public async Task<Sensor_Data?> DeleteSensorData(int Sensor_Data_Id)
        {
            Sensor_Data? dataToDelete = await GetSensorData(Sensor_Data_Id);

            if (dataToDelete != null)
            {
                _db.Sensor_Data.Remove(dataToDelete);
                await _db.SaveChangesAsync();
            }

            return dataToDelete;
        }
    }
}