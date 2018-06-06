using BeyondTask.Models.Entities.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeyondTask.Models.Entities.Models
{
    [Table("Customer")]
    public class Customer : IEntity
    {
        [Key]
        [Column("CustomerId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(10, ErrorMessage = "Name can't be Less than 10 characters")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date Of Birth is required")]
        [AgeRangeValidation(ErrorMessage = "Age must be between 1 - 100", MinAge = 1, MaxAge = 100)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public int GenderId { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Phone(ErrorMessage = "Enter Valid Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Enter Valid Mail")]
        public string Email { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        public Gender Gender { get; set; }
    }
}
