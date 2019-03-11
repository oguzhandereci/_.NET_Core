using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Identity_.NETCore.Models.IdentityModels
{
    public class AppRole:IdentityRole
    {
        [StringLength(128)]
        public string Desc { get; set; }
    }
}
