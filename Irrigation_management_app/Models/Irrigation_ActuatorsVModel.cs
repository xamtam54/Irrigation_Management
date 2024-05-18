using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class Irrigation_ActuatorsVModel
    {
        [Key]
        public int Irrigation_Actuator_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [ForeignKey("Device")]

        public int Device_Id { get; set; }
        public DevicesVModel? Device { get; set; }

        [ForeignKey("Irrigation_Actuators_Type")]
        public int Irrigation_Actuators_Type_Id { get; set; }
        public Irrigation_Actuators_TypesVModel? Irrigation_Actuators_Type { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
