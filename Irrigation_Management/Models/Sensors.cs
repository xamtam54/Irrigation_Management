using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Sensors
    {
        [Key]
        public int Sensor_Id { get; set; }
        //-------------------------------------------------------------------------------------
        public int Sensor_Type_Id { get; set; }
        public Sensor_Types? Sensor_Types { get; set; }
        public int Device_Id { get; set; }
        public Devices? Devices { get; set; }
    }
}
