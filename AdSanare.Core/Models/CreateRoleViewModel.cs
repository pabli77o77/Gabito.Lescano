using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdSanare.Core.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [DisplayName("Nombre")]
        public string RoleName { get; set; }
    }
}
