using System;
using System.Collections.Generic;

namespace Raspertise.Models {

    public class Advertisement {

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int SponsorId { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateStop { get; set; }
        public decimal TotalCost { get; set; }

        public Location Location { get; set; }
        public Sponsor Sponsor { get; set; }

    }

}