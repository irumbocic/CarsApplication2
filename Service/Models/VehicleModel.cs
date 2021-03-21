using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Service.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VehicleMake")]
        [Required]
        public int MakeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }

        //PROVJERITI STO OVO RADI i zasto bez njega nije htio modelBuilder raditi

        public virtual VehicleMake VehicleMake { get; set; }
    }
}
