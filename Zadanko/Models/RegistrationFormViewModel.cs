using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Zadanko.Infrastructure;

namespace Zadanko.Models
{
    public class RegistrationFormViewModel
    {
     
        [Required(ErrorMessage = "Musisz podać imię.")]
        [Display(Name = "Imię:")]
        public string FName { get; set; }
       
        [Required(ErrorMessage = "Musisz podać nazwisko.")]
        [Display(Name = "Nazwisko:")]
        public string LName { get; set; }
       
        [Required(ErrorMessage = "Musisz podać adres email.")]
        [EmailAddress(ErrorMessage = "Wpisz poprawny adres email.")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [RegularExpression("^.*(?=.{8,})(?=.*[0-9])(?=.*[a-zA-Z]).*$", ErrorMessage = "Hasło musi posiadać przynajmniej jedną wielką literę i jedną cyfrę")]
        [Required(ErrorMessage = "Musisz podać hasło.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło:")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Podane hasła nie zgadzają się!")]
        [Display(Name = "Potwierdź hasło:")]
        public string PasswordRepeat { get; set; }
        

        [FileValidation(ErrorMessage = "Wielkosc pliku nie może przekraczać 2mb")]
        [Display(Name = "Dowód zakupu:")]
        public byte[] Receipt { get; set; }
        

        [Display(Name = "Zainteresowania:")]
        public List<Interest> Interests { get; set; }
      
        [Display(Name = "Czy chcesz dodać zainteresowania?")]
        public bool AdditionalInterestsWill { get; set; }
      
        public List<string> AdditionalInterests { get; set; }
    }


}