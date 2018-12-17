using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ToolsForEverApplication.Models
{
    public class AddtoVoorraadViewModel
    {
        [Required]
        [Display(Name = "Voorraad")]
        public int extravoorraad { get; set; }
    }
}