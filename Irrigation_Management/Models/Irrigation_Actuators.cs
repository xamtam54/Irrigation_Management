using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Irrigation_Actuators
    {
        [Key]
        public int Irrigation_Actuator_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [ForeignKey("Device")]

        public int Device_Id { get; set; }
        public Devices? Device { get; set; }

        [ForeignKey("Irrigation_Actuators_Type")]
        public int Irrigation_Actuators_Type_Id { get; set; }
        public Irrigation_Actuators_Types? Irrigation_Actuators_Type { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
