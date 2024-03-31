using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Planting_Areas
    {
        [Key]
        public int Area_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [ForeignKey("Crop_Status")]
        public int Crop_Status_Id { get; set;}
        public Crop_Status? Crop_Status { get; set; }
        public int Plant_Id { get; set;}
        public Plants? Plants { get; set; }
    }
}
