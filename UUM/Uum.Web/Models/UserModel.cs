using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uum.Web.Models
{
    /// <summary>
    /// Users properties
    /// </summary>
    [Table("Users")]
    public class UserModel
    {
        /// <summary>
        /// Id properties
        /// </summary>
        [Display(Name = "Id")]
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
        /// Guardian's Full Name properties
        /// </summary>
        [Display(Name = "GuardianFullName")]
        public string GuardianFullName { get; set; }

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

        /// <summary>
        /// Tel properties
        /// </summary>
        [Display(Name = "Tel")]
        public string Tel { get; set; }

        /// <summary>
        /// TypeUser properties
        /// </summary>
        [Display(Name = "TypeUser")]
        public string TypeUser { get; set; }

        /// <summary>
        /// User properties
        /// </summary>
        [Display(Name = "Logins")]
        public List<LoginModel> Logins { get; set; }

        /// <summary>
        /// Address properties
        /// </summary>
        [Display(Name = "Address")]
        public List<AddressModel> Address { get; set; }
    }
}
