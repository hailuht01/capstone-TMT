﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Landmark
    {

        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longtiude { get; set; }
        public string PicName { get; set; }
        public string QueryString => Name.Trim().Replace(' ', '+');
        public bool? ThumbsUp { get; set; }

        public DateTime LastUpdated { get; set; }

        public Landmark() { }

        public Landmark(string ID, string Name, string Address, string Description, double Latitude, double Longitude, string PicName)
        {
            this.PlaceId = ID;
            this.Name = Name;
            this.Address = Address;
            this.Description = Description;
            this.Latitude = Latitude;
            this.Longtiude = Longitude;
            this.PicName = PicName;
        }

        public static List<Landmark> GetSamples() => new List<Landmark>()
    {
        new Landmark("ChIJ7Qfv_ZqzQYgRSV2kwAcCB4s", "Cincinnati Zoo", "3400 Vine St, Cincinnati, OH 45220", " The second oldest Zoo in the United States. Wide variety of animal collection.The Zoo was founded on 65 acres in the middle of the city, and since then has acquired some of the surrounding blocks and several reserves in Cincinnati’s suburbs.", 39.144573, -84.508617, "Cincinnati-Zoo.jpg"),
        new Landmark("ChIJuZQ4_x20QYgR2QLQxS_400g", "Cincinnati Museum Center", "1301 Western Ave, Cincinnati, OH 45203", "Family Friendly Museum! This place its awesome! You are really going to love it.", 39.110019, -84.537781, "Cincinnati-Museum.jpg"),
        new Landmark("ChIJi77WfdCzQYgRGbJHVBDHy-g", "Krohn Conservatory", "1501 Eden Park Dr, Cincinnati, OH 45202", "Blooming Conservatory! Because plants are super cool! Don't miss out.", 39.115235, -84.489999, "Krohn-Conservatory.jpg"),
        new Landmark("ChIJT-TnLv6zQYgRElWrTagIgJ4", "Music Hall", "1241 Elm Street, Cincinnati, Ohio", " A classical music performance hall Don't miss out.", 39.109395, -84.519231, "Music-Hall.jpg"),
        new Landmark("ChIJfVEQdNSzQYgRGubreDvtpcY", "Fountain Square", " 520 Vine St, Cincinnati, OH 45202", "Fountain Square is the city square; features many shops, restaurants, hotels, and offices.", 39.101789, -84.512794, "Fountain-Square.jpg"),
        new Landmark("ChIJj5FhLG-xQYgRNhr-7ontbKo", "Newport On the Levee", "1 Levee Way, Newport, KY 41071", "Newport on the Levee is a premier dining and attraction destination!", 39.094690, -84.496364, "Newport-On-the-Levee.jpg"),
        new Landmark("EjxKb2huIEEuIFJvZWJsaW5nIFN1c3BlbnNpb24gQnJpZGdlLCBDb3Zpbmd0b24sIEtZIDQxMDExLCBVU0E", "John A. Roebling Suspension Bridge","1501 Eden Park Dr, Cincinnati, OH 45202", "The John A. Roebling Suspension Bridge, originally known as the Cincinnati-Covington Bridge spans the Ohio River between Cincinnati, Ohio and Covington, Kentucky", 39.092993, -84.509864, "John A. Roebling Suspension Bridge.jpg"),

    };

    }
}