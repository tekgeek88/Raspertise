using Raspertise.Models;
using System;
using System.Linq;

namespace Raspertise.Data {

    public static class DbInitialize {

        public static void Initialize(RaspertiseContext context) {

            context.Database.EnsureCreated();
            
            /**************************************************
             *           Add Sponsor Sample Data
             *************************************************/
            // Look for any Sponsors
            if (context.Sponsors.Any()) {
                return; // DB has already been seeded with data
            }

            var sponsors = new Sponsor[] {
                new Sponsor{FirstName = "Carl", LastName = "Argabright", Email = "tekgeek88@yahoo.com", Phone = "253-590-9132", PaymentMethod = PaymentMethod.Cash},
                new Sponsor{FirstName = "Sara", LastName = "Argabright", Email = "sara.argabright@gmail.com", Phone = "253-226-1781", PaymentMethod = PaymentMethod.CreditCard},
                new Sponsor{FirstName = "Dylan", LastName = "Rankin", Email = "dylan.rankin@gmail.com", Phone = "253-555-1111", PaymentMethod = PaymentMethod.PayPal}
            };

            foreach (Sponsor s in sponsors) {
                context.Sponsors.Add(s);
            }
            context.SaveChanges();
            
            
            /**************************************************
             *           Add Advertiser Sample Data
             *************************************************/
            // Look for any Advertisers
            if (context.Advertisers.Any()) {
                return; // DB has already been seeded with data
            }

            var advertisers = new Advertiser[] {
                new Advertiser{FirstName = "Luke", LastName = "Gilmore", Email = "luke@gmail.com", Phone = "253-565-1234", AmountEarned = 0},
                new Advertiser{FirstName = "Jason", LastName = "T-Mobile", Email = "jason@tmobile.com", Phone = "253-555-1111", AmountEarned = 0},
                new Advertiser{FirstName = "Andy", LastName = "Kim", Email = "hush.mail@gmail.com", Phone = "253-111-2222", AmountEarned = 0}
            };

            foreach (Advertiser a in advertisers) {
                context.Advertisers.Add(a);
            }
            context.SaveChanges();
            
            
            /**************************************************
             *           Add Location Sample Data
             *************************************************/
            // Look for any Advertisers
            if (context.Locations.Any()) {
                return; // DB has already been seeded with data
            }

            var locations = new Location[] {
                new Location{AdvertiserId = 1, Description = "My Uber - Passenger Side", PricePerDay = 1.00m},
                new Location{AdvertiserId = 2, Description = "Voodoo Donut Shop", PricePerDay = 2.99m},
                new Location{AdvertiserId = 3, Description = "12th and broadway", PricePerDay = 5.99m},
                new Location{AdvertiserId = 1, Description = "My Uber - Passenger Side", PricePerDay = 1.75m}
            };

            foreach (Location l in locations) {
                context.Locations.Add(l);
            }
            context.SaveChanges();
            
            
            /**************************************************
             *           Add Advertisement Sample Data
             *************************************************/
            // Look for any Advertisements
            if (context.Advertisements.Any()) {
                return; // DB has already been seeded with data
            }

            var advertisements = new Advertisement[] {
                new Advertisement{LocationId = 1, SponsorId = 1,
                    Message = "Enrique's Landscaping Service - 50% of this week! Call 253-639-1234 for a free quote today!", 
                    Color = "255, 0, 0", 
                    DateStart = DateTime.Parse("07-15-2019"), 
                    DateStop = DateTime.Parse("07-22-2019"), 
                    TotalCost = 100m},
                new Advertisement{LocationId = 1, SponsorId = 2,
                    Message = "Sara's Shear Beauty and Hair Care - Free scalp massage with haircut! Call 253-555-1234 to make an appt today!", 
                    Color = "0, 0, 255", 
                    DateStart = DateTime.Parse("07-15-2019"), 
                    DateStop = DateTime.Parse("08-15-2019"), 
                    TotalCost = 200m},
                new Advertisement{LocationId = 1, SponsorId = 3,
                    Message = "Coco's Pet Day Care - Free dog wash for stays of 2 nights or more! Call 253-555-1234 to make a reservation today!", 
                    Color = "0, 255, 0", 
                    DateStart = DateTime.Parse("07-15-2019"), 
                    DateStop = DateTime.Parse("09-1-2019"), 
                    TotalCost = 200m}
            };

            foreach (Advertisement a in advertisements) {
                context.Advertisements.Add(a);
            }
            context.SaveChanges();

        }
        

        

    }

}