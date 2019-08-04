using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raspertise.Models {

    public class Advertiser {
        

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            
            [Column(TypeName="money")]
            public decimal AmountEarned { get; set; }

            public ICollection<Location> Locations { get; set; }

    }

}