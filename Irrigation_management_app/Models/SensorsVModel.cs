using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class SensorsVModel
    {
        [Key]
        public int Sensor_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [ForeignKey("Sensor_Type")]

        public int Sensor_Type_Id { get; set; }
        public Sensor_TypesVModel? Sensor_Type { get; set; }
        [ForeignKey("Device")]

        public int Device_Id { get; set; }
        public DevicesVModel? Device { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
