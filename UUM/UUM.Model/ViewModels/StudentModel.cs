using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UUM.Model.ViewModels
{
    /// <summary>
    /// Student properties
    /// </summary>
    [Table("Students")]
    public class StudentModel
    {
        /// <summary>
        /// Id properties
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Login associated with that user
        /// </summary>
        [Display(Name = "User")]
        public UserModel User { get; set; }

        /// <summary>
        /// Address properties
        /// </summary>
        [Display(Name = "Address")]
        public AddressModel Address { get; set; }

        /// <summary>
        /// Course properties
        /// </summary>
        [Display(Name = "Course")]
        public CourseModel Course { get; set; }

        /// <summary>
        /// Report Card properties
        /// </summary>
        [Display(Name = "ReportCard")]
        public ReportCardModel ReportCard { get; set; }

        /// <summary>
        /// Registration Date (dd/mm/yyyy)
        /// </summary>
        [Display(Name = "RegistrationDate")]
        public string RegistrationDate { get; set; }

        /// <summary>
        /// Completion Date (dd/mm/yyyy)
        /// </summary>
        [Display(Name = "CompletionDate")]
        public string CompletionDate { get; set; }

        /// <summary>
        /// Transfer Date (dd/mm/yyyy)
        /// </summary>
        [Display(Name = "TransferDate")]
        public string TransferDate { get; set; }

        /// <summary>
        /// Lockout Date (dd/mm/yyyy)
        /// </summary>
        [Display(Name = "LockoutDate")]
        public string LockoutDate { get; set; }
    }
}
