﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Irrigation_management_app.Models
{
    public class DevicesVModel
    {
        [Key]
        public int Device_Id { get; set; }
        //-------------------------------------------------------------------------------------
        [StringLength(50)]
        public required string Device_Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public required decimal Device_Price { get; set; }
        //-------------------------------------------------------------------------------------
        [Range(0, 1, ErrorMessage = "El valor debe estar entre 0 y 1")]
        public int Device_Enabled { get; set; } = 1;
        //-------------------------------------------------------------------------------------
        [ForeignKey("System")]

        public int System_Id { get; set; }
        public SystemsVModel? System { get; set; }
        [ForeignKey("Planting_Area")]

        public int? Area_Id { get; set; }
        public Planting_AreasVModel? Planting_Area { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
