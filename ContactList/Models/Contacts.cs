using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactList.Models
{
    public class Contact
    {
        [Required]
        [RegularExpression (@"^[0-9]+$",ErrorMessage ="Only numbers are allowed")]
        [Display(Name ="ID")]

        public int Id { get; set; }
        [Required]
        
        [DataType(DataType.Text)]
        [StringLength (35)]
        //[RegularExpression(@"^[\p{L} .'-]+$", ErrorMessage = "Not a valid First Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Not a valid First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(35)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage ="Not a valid Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //[DataType(DataType.PhoneNumber)]
        //[StringLength(10,ErrorMessage ="Phone number should contain 10 numbers",MinimumLength =10)]
        [RegularExpression(@"^[0-9]{10}$",ErrorMessage ="Not a valid phone number")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Status { get; set; }
        //public enum Status1 { Active, Inactive }
        //public struct ConvertEnum
        //{
        //    public int Value { get; set; }
        //    public string Text { get; set; }
        //}

        //List<ConvertEnum> myStatus = new List<ConvertEnum>();
        //foreach(Status st in Enum.GetValues(typeof(Status))) mystatus

        //public IEnumerable<String> Status { get; set; }
        

    }
}