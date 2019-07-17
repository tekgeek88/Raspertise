using System.Collections.Generic;

namespace Raspertise.Models {

    public class Advertiser {
        

            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public decimal AmountEarned { get; set; }

            public ICollection<Location> Locations { get; set; }

    }

}