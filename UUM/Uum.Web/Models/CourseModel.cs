using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uum.Web.Models
{
    /// <summary>
    /// Address properties
    /// </summary>
    [Table("Address")]
    public class CourseModel
    {
        /// <summary>
        /// Id properties
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Course Name
        /// </summary>
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Curriculum JSON
        /// </summary>
        [Display(Name = "Curriculum")]
        public string Curriculum { get; set; }

        /// <summary>
        /// Address properties
        /// </summary>
        [Display(Name = "Address")]
        public AddressModel Address { get; set; }

        /// <summary>
        /// School Periods
        /// </summary>
        [Display(Name = "SchoolPeriods")]
        public string SchoolPeriods { get; set; }

        /// <summary>
        /// Evaluation Periods
        /// </summary>
        [Display(Name = "EvaluationPeriods")]
        public string EvaluationPeriods { get; set; }

        /// <summary>
        /// Banknote Delivery Period
        /// </summary>
        [Display(Name = "BanknoteDeliveryPeriod")]
        public string BanknoteDeliveryPeriod { get; set; }
    }
}
