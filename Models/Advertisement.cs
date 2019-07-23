using System;
using System.ComponentModel.DataAnnotations;


namespace Raspertise.Models {

    public class Advertisement {

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int SponsorId { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStop { get; set; }
        public decimal TotalCost { get; set; }
        public Location Location { get; set; }
        public Sponsor Sponsor { get; set; }

    }

}