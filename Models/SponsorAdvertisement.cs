namespace Raspertise.Models {

    public class SponsorAdvertisement {

        public int SponsorId { get; set; }

        public int AdvertisementId { get; set; }

        public Sponsor Sponsor { get; set; }

        public Advertisement Advertisement { get; set; }

    }

}