using System.ComponentModel.DataAnnotations;
using System;

namespace Core.DTOs
{
    public class MotorbikeDto : VehicleDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Plate { get; set; }

        public string GetVehicleType()
        {
            return "Motorbike";
        }
    }
}
