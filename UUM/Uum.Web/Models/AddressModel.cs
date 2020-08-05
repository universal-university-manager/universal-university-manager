using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uum.Web.Models
{
    /// <summary>
    /// Address properties
    /// </summary>
    [Table("Addresses")]
    public class AddressModel
    {
        /// <summary>
        /// Id properties
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// State properties
        /// </summary>
        [Display(Name = "State")]
        public string State { get; set; }

        /// <summary>
        /// City properties
        /// </summary>
        [Display(Name = "City")]
        public string City { get; set; }

        /// <summary>
        /// Address properties
        /// </summary>
        [Display(Name = "Street")]
        public string Street { get; set; }

        /// <summary>
        /// Number properties
        /// </summary>
        [Display(Name = "Number")]
        public byte Number { get; set; }

        /// <summary>
        /// ZipCode properties
        /// </summary>
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }
    }
}
