using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raspertise.Models {

    public enum PaymentMethod {

        Cash, CreditCard, PayPal

    }

    public class Sponsor {

        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        [Display(Name = "Payment Method")]
        public PaymentMethod? PaymentMethod { get; set; }

        public ICollection<Advertisement> Advertisments { get; set; }

    }

}