using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Sensor_Data
    {
        [Key]
        public int Sensors_Data_Id { get; set; }
        //-------------------------------------------------------------------------------------
        public DateTime Date_Time { get; set; }
        public float Data { get; set; }
        //-------------------------------------------------------------------------------------
        public int Sensor_Id { get; set; }
        public Sensors? Sensor_Type { get; set; }
    }
}
