using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models{
    public class User{
        [Key]
        public int UserId { get; set; }

        // [Required]
        [Display(Name="First Name: ")]
        // [MinLength(2, ErrorMessage="First Name must be at least 2 characters!")]
        public string FirstName { get; set; }

        // [Required]
        [Display(Name="Last Name: ")]
        // [MinLength(2,ErrorMessage="Last Name must be at least 2 characters!")]
        public string  LastName { get; set; }

        // [Required]
        [EmailAddress]
        [Display(Name="Email: ")]
        public string Email { get; set; }


        // [Required]
        [Display(Name="Password: ")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password { get; set; }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [NotMapped]
        [Display(Name="Confirm Password: ")]
        [Compare("Password", ErrorMessage="Confirm password is incorrect!")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        // user can have many messages
        public List<Message> Messages { get; set; }

        //user can have many comments 
        public List<Comment> Comments { get; set; }
        //TODO many to many connect to other Model
    }

}