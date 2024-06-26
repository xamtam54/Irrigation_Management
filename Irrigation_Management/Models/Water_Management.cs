﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Device")]

        public int Device_Id { get; set; }
        public Devices? Device { get; set; }
        [ForeignKey("Water_Management_Type")]

        public int Water_Management_Type_Id { get; set; }
        public Water_Management_Types? Water_Management_Type { get; set; }
        //-------------------------------------------------------------------------------------
        public bool IsDeleted { get; internal set; } = false;
    }
}
