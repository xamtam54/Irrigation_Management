using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class Planting_AreasVModel
    {
        [Key]
        public int Area_Id { get; set; }
        public string Area_Name { get; set; } = "area1";
        //-------------------------------------------------------------------------------------
        [ForeignKey("Crop_Statu")]
        public int Crop_Status_Id { get; set; }
        public Crop_StatusVModel? Crop_Statu { get; set; }
        [ForeignKey("Plant")]

        public int Plant_Id { get; set; }
        public PlantsVModel? Plant { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
