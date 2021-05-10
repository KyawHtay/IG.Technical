using System;
using System.ComponentModel.DataAnnotations;

namespace IG.TechnicalInterview.Model.Supplier
{
    public class Phone
    {
        /// <summary>
        /// Gets or sets the phone id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        [Required]
        [MaxLength(10)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the email is the preferred one or not
        /// </summary>
        public bool IsPreferred { get; set; }
    }
}