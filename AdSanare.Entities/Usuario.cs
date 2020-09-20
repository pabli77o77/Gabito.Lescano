using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdSanare.Entities
{
    public class Usuario : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [PersonalData]
        [Column(TypeName = "int")]
        public int EmployeeFileNumber { get; set; }
    }
}
