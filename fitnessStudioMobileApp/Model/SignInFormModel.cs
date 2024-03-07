using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Compatibility;
using Syncfusion.Maui.DataForm;

namespace fitnessStudioMobileApp.Model
{
    public class SignInFormModel
    {
        #region Constructor
        public SignInFormModel()
        {
            this.FullName = string.Empty;
            this.Email = string.Empty;
            this.Password = string.Empty;
            this.PhoneNumber = string.Empty;
            this.ConfirmPassword = string.Empty;
            this.HomeAddress = string.Empty;
        }

        #endregion

        #region Property
        [Display(Name = "Full Name", Prompt = "Please enter your full name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your full name")]
        [DataFormDisplayOptions(ValidMessage = "Valid name")]
        public string FullName { get; set; }

        [Display(Name = "Email", Prompt = "example@gamil.com")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        [DataFormDisplayOptions(ValidMessage = "Valid email")]
        public string Email { get; set; }

        [Display(Name = "Password", Prompt = "Please enter your password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be greater than 6 characters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password", Prompt = "Please confirm your password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be greater than 6 characters")]
        public string ConfirmPassword { get; set;}

        [Display(Name = "Phone Number", Prompt = "Please enter your phone number without '-'")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Invalid phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, ErrorMessage = "Invalid phone number")]
        [DataFormDisplayOptions(ValidMessage = "Valid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Home Address", Prompt = "Please enter your home address")]
        [DataType(DataType.MultilineText)]
        public string HomeAddress { get; set; }

        #endregion
    }
}
