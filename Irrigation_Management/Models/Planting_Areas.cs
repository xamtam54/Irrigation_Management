using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Irrigation_Management.Models
{
    public class Planting_Areas
    {
        [Key]
        public int Area_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [ForeignKey("Crop_Statu")]
        public int Crop_Status_Id { get; set;}
        public Crop_Status? Crop_Statu { get; set; }
        [ForeignKey("Plant")]

        public int Plant_Id { get; set;}
        public Plants? Plant { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
