using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;


namespace Raspertise.Models {

    public class Advertisement {

        public int Id { get; set; }
        
        [Display(Name = "Location Id")]
        public int LocationId { get; set; }
        
        [Display(Name = "Sponsor Id")]
        public int SponsorId { get; set; }
        
        public string Message { get; set; }
        
        public string Color { get; set; }
        
        [Range(1, 5)]
        public int Speed { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime DateStart { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Stop Date")]
        public DateTime DateStop { get; set; }
        
        [Display(Name = "Total Cost")]
        [Column(TypeName="money")]
        public decimal TotalCost { get; set; }
        
        public Location Location { get; set; }
        
        public Sponsor Sponsor { get; set; }

    }

}