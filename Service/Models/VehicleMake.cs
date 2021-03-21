using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Models
{
    public class VehicleMake
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }

        //PROVJERITI STO OVO RADI i zasto bez njega nije htio modelBuilder raditi
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
