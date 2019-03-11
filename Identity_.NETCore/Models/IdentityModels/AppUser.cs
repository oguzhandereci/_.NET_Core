using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Identity_.NETCore.Models.IdentityModels
{
    public class AppUser:IdentityUser
    {
        [Required,StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Surname { get; set; }

        public DateTime RegisteredDate { get; set; } = DateTime.Now;
    }
}
