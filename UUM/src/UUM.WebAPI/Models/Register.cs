using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UUM.WebAPI.Models
{
    /// <summary>
    /// Model example register
    /// </summary>
    [Table("Register")]
    public class Register
    {
        /// <summary>
        /// Id properties for database
        /// </summary>
        [Display(Name = "Code")]
        public int Id { get; set; }

        /// <summary>
        /// Name properties
        /// </summary>
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Last name properties
        /// </summary>
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// CPF/CNPJ properties
        /// </summary>
        [Display(Name = "CpfCnpj")]
        public string CpfCnpj { get; set; }

        /// <summary>
        /// Age properties
        /// </summary>
        [Display(Name = "Age")]
        public byte Age { get; set; }
    }
}
