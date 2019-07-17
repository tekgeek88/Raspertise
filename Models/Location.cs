using System.Collections.Generic;

namespace Raspertise.Models {

    public class Location {

        public int Id { get; set; }
        public int AdvertiserId { get; set; }
        public string Description { get; set; }
        public decimal PricePerDay { get; set; }

        // This is a navigation property - A location can have any number of advertisments
        private ICollection<Advertisement> Advertisements { get; set; }

    }

}