using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
