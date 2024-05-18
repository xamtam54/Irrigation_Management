using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class Sensor_DataVModel
    {
        [Key]
        public int Sensors_Data_Id { get; set; }
        //-------------------------------------------------------------------------------------
        public DateTime Date_Time { get; set; }
        public float Data { get; set; }
        //-------------------------------------------------------------------------------------
        [ForeignKey("Sensor")]

        public int Sensor_Id { get; set; }
        public SensorsVModel? Sensor { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
