using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace EgyptExploring.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Please Enter The Same Password As Above")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string Email {  get; set; }
    }
}
