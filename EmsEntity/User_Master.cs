using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmsEntity
{
    public class User_Master
    {
        /// <summary>
        /// UserID. Primary Key. Maximum length: 6.
        /// </summary>
        
        [Key]
        [StringLength(6)]
        [DisplayName("User ID")]
        public string UserID { get; set; }

        /// <summary>
        /// UserName. Cannot be less than 8 characters. 
        /// </summary>
        
        [Required]
        [MinLength(8, ErrorMessage = "Username must be at least 8 characters long.")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        /// <summary>
        /// UserPassword. Password. Maximum length: 50.
        /// </summary>
        
        [Required]
        [StringLength(50)]
        [DisplayName("User Password")]
        public string UserPassword { get; set; }

        /// <summary>
        /// UserType. Supervisor (SU) or Regular user (RU). Only a supervisor can upload the file. As of now, it is only admin. Maximum length: 2.
        /// </summary>
        
        [Required]
        [StringLength(2)]
        [DisplayName("User Type")]
        [RegularExpression(@"^(RU|SU)$", ErrorMessage = "Enter RU for Regular User or SU for Supervisor User")]
        public string UserType { get; set; }

    }
}
