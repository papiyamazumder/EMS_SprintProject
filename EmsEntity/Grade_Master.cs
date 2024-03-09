using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmsEntity
{
    public class Grade_Master
    {
        /// <summary>
        /// Grade_Code. Primary Key. Maximum length: 2.
        /// </summary>
        [Key]
        [Required]
        [StringLength(2)]
        [DisplayName("Grade Code")]
        public string Grade_Code { get; set; }

        /// <summary>
        /// Description. For Describing for example - Associates, Executive, Managers etc. Maximum length: 10.
        /// </summary>
        [Required]
        [StringLength(10)]
        [DisplayName("Grade Description")]
        public string Description { get; set; }

        /// <summary>
        /// Min_Salary. Lower Salary band. Not Null.
        /// </summary>
        [Required]
        [DisplayName("Minimum Salary")]
        public int Min_Salary { get; set; }

        /// <summary>
        /// Max_Salary. Upper Salary Band. Not Null.
        /// </summary>
        [Required]
        [DisplayName("Maximum Salary")]
        public int Max_Salary { get; set; }
    }
}
