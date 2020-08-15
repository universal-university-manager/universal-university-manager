using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UUM.Model.ViewModels
{
    /// <summary>
    /// Teaching Unit properties
    /// </summary>
    [Table("TeachingUnits")]
    public class TeachingUnitModel
    {
        /// <summary>
        /// Id properties
        /// </summary>
        [Display(Name = "Id")] 
        public int Id { get; set; }

        /// <summary>
        /// Address properties
        /// </summary>
        [Display(Name = "Address")]
        public AddressModel Address { get; set; }

        /// <summary>
        /// full name of the person responsible for the unit
        /// </summary>
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Headquarters or subsidiary
        /// </summary>
        [Display(Name = "TypeUnit")]
        public string TypeUnit { get; set; }
    }
}
