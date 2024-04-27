using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Sensor")]

        public int Sensor_Id { get; set; }
        public Sensors? Sensor { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
