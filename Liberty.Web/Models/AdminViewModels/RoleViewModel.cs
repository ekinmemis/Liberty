using System.ComponentModel.DataAnnotations;

namespace Liberty.Web.Models.AdminViewModels
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }
}