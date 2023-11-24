using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Plate { get; set; }
    }
}
