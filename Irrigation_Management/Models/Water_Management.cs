using System.ComponentModel.DataAnnotations;

namespace Irrigation_Management.Models
{
    public class Water_Management
    {
        [Key]
        public int Water_Management_Id { get; set; }
        //-------------------------------------------------------------------------------------
        public required float Capacity { get; set; }
        public float? Collection_Hour { get; set; } = null;
        //-------------------------------------------------------------------------------------
        public int Device_Id { get; set; }
        public Devices? Devices { get; set; }
        public int Water_Management_Type_Id { get; set; }
        public Water_Management_Types? Water_Management_Types { get; set; }
    }
}
