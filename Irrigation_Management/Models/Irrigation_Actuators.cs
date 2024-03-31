using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Irrigation_Actuators
    {
        [Key]
        public int Irrigation_Actuator_Id { get; set; }
        //-------------------------------------------------------------------------------------
        public int Device_Id { get; set; }
        public Devices? Devices { get; set; }
        public int Irrigation_Actuators_Type_Id { get; set; }
        public Irrigation_Actuators_Types? Irrigation_Actuators_Types { get; set; }
    }
}
