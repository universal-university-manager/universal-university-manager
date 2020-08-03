using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uum.Web.Models
{
    /// <summary>
    /// Report Card properties
    /// </summary>
    [Table("Address")]
    public class ReportCardModel
    {
        /// <summary>
        /// Id properties
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Average Grade
        /// </summary>
        [Display(Name = "AverageGrade")]
        public float AverageGrade { get; set; }

        /// <summary>
        /// P1 Grades
        /// </summary>
        [Display(Name = "P1")]
        public float P1 { get; set; }

        /// <summary>
        /// P2 Grades
        /// </summary>
        [Display(Name = "P2")]
        public float P2 { get; set; }

        /// <summary>
        /// Sub Grades
        /// </summary>
        [Display(Name = "Sub")]
        public float Sub { get; set; }

        /// <summary>
        /// Exa Grades
        /// </summary>
        [Display(Name = "Exa")]
        public float Exa { get; set; }

        /// <summary>
        /// Presence days
        /// </summary>
        [Display(Name = "Presence")]
        public byte Presence { get; set; }

        /// <summary>
        /// Fouls days
        /// </summary>
        [Display(Name = "Fouls")]
        public byte Fouls { get; set; }

        /// <summary>
        /// Frequency (%)
        /// </summary>
        [Display(Name = "Frequency")]
        public string Frequency { get; set; }
    }
}
