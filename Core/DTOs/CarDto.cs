using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public class CarDto : VehicleDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Plate { get; set; }

        public String GetVehicleType()
        {
            return "Car";
        }
    }
}
