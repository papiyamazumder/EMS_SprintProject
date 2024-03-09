using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class Employee
    {
        /// <summary>
        /// Emp_ID. Primary Key. Maximum length: 6. Employee ID Cannot start with Zero. 
        /*  
         *  [RegularExpression(
            @"^[1-9]        -> Start with a digit from 1 to 9
            [0-9]*          -> Followed by zero or more digits (including zero)
            $               -> End of string
            
            )]
        */
        /// </summary>  
        [Key]
        [StringLength(6)]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Employee ID cannot start with zero.")]
        [DisplayName("ID")]
        public string Emp_ID { get; set; }

        /// <summary>
        /// Emp_First_Name. Not Null. Maximum length: 25. Employee's First Name. E.g. Bill in Bill Gates.
        /// </summary>
        [Required]
        [StringLength(25)]
        [DisplayName("First Name")]
        public string Emp_First_Name { get; set; }

        /// <summary>
        /// Emp_Last_Name. Maximum length: 25. Employee's Last Name. E.g. Gates in Bill Gates.
        /// </summary>
        [StringLength(25)]
        [DisplayName("Last Name")]
        public string Emp_Last_Name { get; set; }

        /// <summary>
        /// Emp_Date_of_Birth. Not Null. Employee's Date of Birth. Must be minimum 18 years old and maximum 58 years old.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime Emp_Date_of_Birth { get; set; }

        /// <summary>
        /// Emp_Date_of_Joining. Not Null. Employee's Date of Joining. Must be greater than Date of Birth.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Joining")]
        public DateTime Emp_Date_of_Joining { get; set; }

        /// <summary>
        /// Emp_Dept_ID. Foreign Key. Employee's Department ID.
        /// </summary>
        [ForeignKey("Department")]
        [DisplayName("Department ID")]
        public int Emp_Dept_ID { get; set; }

        /// <summary>
        /// Emp_Grade. Not Null. M1, M2, M3…M7. Employee's Grade.
        /// </summary>
        [Required]
        [StringLength(2)]
        //[ForeignKey("Grade_Master")]
        [DisplayName("Grade")]
        public string Emp_Grade { get; set; }

        /// <summary>
        /// Emp_Designation. Employee's Designation. Maximum length: 50.
        /// </summary>
        [StringLength(50)]
        [DisplayName("Designation")]
        public string Emp_Designation { get; set; }

        /// <summary>
        /// Emp_Basic. Not Null. Employee's Basic Salary.
        /// </summary>
        [Required]
        [DisplayName("Basic")]
        public int Emp_Basic { get; set; }

        /// <summary>
        /// Emp_Gender. Not Null. Single Character to determine its M or F. Employee's Gender.
        /// </summary>
        [Required]
        [StringLength(1)]
        [DisplayName("Gender")]
        public string Emp_Gender { get; set; }

        /// <summary>
        /// Emp_Marital_Status. Not Null. Single Character. Employee's Marital Status.
        /// </summary>
        [Required]
        [StringLength(1)]
        [DisplayName("Marital Status")]
        public string Emp_Marital_Status { get; set; }

        /// <summary>
        /// Emp_Home_Address. Employee's Home Address. Maximum length: 100.
        /// </summary>
        [StringLength(100)]
        [DisplayName("Home Address")]
        public string Emp_Home_Address { get; set; }

        /// <summary>
        /// Emp_Contact_Num. Employee's Contact Number. Maximum length: 15.
        /// </summary>
        [StringLength(15)]
        [DisplayName("Personal Contact Number")]
        public string Emp_Contact_Num { get; set; }
    }
}
