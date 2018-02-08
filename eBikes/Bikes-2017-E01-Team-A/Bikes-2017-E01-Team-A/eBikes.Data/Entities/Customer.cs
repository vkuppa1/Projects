using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace eBikes.Data.Entities
{

    public class Customer
    {
        [Key]

        public int CustomerID { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [StringLength(30, ErrorMessage = "LastName is limited to 30 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [StringLength(30, ErrorMessage = "FirstName is limited to 30 characters.")]
        public string FirstName { get; set; }

        [StringLength(40, ErrorMessage = "Address is limited to 40 characters.")]
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "City is limited to 20 characters.")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "Province is limited to 2 characters.")]
        public string Province { get; set; }

        [StringLength(6, ErrorMessage = "PostalCode is limited to 6 characters.")]
        public string PostalCode { get; set; }

        [StringLength(12, ErrorMessage = "ContactPhone is limited to 12 characters.")]
        public string ContactPhone { get; set; }

        [StringLength(30, ErrorMessage = "EmailAddress is limited to 30 characters.")]
        public string EmailAddress { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
