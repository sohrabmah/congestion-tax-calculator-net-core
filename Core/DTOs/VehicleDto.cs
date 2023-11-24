using System;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs
{
    public interface VehicleDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Plate { get; set; }
        String GetVehicleType();
    }
}
