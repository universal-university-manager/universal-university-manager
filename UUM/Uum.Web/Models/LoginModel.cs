﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uum.Web.Models
{
    /// <summary>
    /// Logins Properties
    /// </summary>
    [Table("Login")]
    public class LoginModel
    {
        /// <summary>
        /// Id properties
        /// </summary>
        [Display(Name = "Id")]
        public int Id { get; set; }

        /// <summary>
        /// Age properties
        /// </summary>
        [Display(Name = "Login")]
        public string Login { get; set; }

        /// <summary>
        /// Age properties
        /// </summary>
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
