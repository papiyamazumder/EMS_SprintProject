using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class Department
    {
        /// <summary>
        /// Department ID. Primary Key. Cannot start with Zero. 
        /// </summary>
        [Key]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Dept_ID cannot start with zero.")]
        [DisplayName("Department ID")]
        public int Dept_ID { get; set; }

        /// <summary>
        /// Department Name, Not Null, Max Length of the string should be 50.
        /// </summary>

        [Required]                              
        [StringLength(50)]
        [DisplayName("Department Name")]
        public string Dept_Name { get; set; }
    }
}
