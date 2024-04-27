using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Sensors
    {
        [Key]
        public int Sensor_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [ForeignKey("Sensor_Type")]

        public int Sensor_Type_Id { get; set; }
        public Sensor_Types? Sensor_Type { get; set; }
        [ForeignKey("Device")]

        public int Device_Id { get; set; }
        public Devices? Device { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
