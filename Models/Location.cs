using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raspertise.Models {

    public class Location {

        public int Id { get; set; }
        public int AdvertiserId { get; set; }
        public string Description { get; set; }
        
        [Column(TypeName="money")]
        public decimal PricePerDay { get; set; }

        // This is a navigation property - A location can have any number of advertisements
        private ICollection<Advertisement> Advertisements { get; set; }

    }

}