using System;
using System.ComponentModel.DataAnnotations;

namespace SynelTestTaskApp.ViewModels
{
    public class HomeEditViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Payroll Number")]
        public string Payroll_Number { get; set; }

        [Display(Name = "First Name")]
        public string Forenames { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime Date_of_Birth { get; set; }

        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Address 2")]
        public string Address_2 { get; set; }

        [Display(Name = "Post Code")]
        public string Postcode { get; set; }

        [Display(Name = "Home Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]
        public string EMail_Home { get; set; }

        [Display(Name = "Start Date")]
        
        public DateTime Start_Date { get; set; }
    }
}
