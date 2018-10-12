using System.Runtime.Serialization;

namespace Loginet.TestTask.Models
{
    [DataContract(Name = "company")]
    public class Address
    {
        [DataMember(Name = "street")]
        public string Street { get; set; }

        [DataMember(Name = "suit")]
        public string Suit { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "zipcode")]
        public string ZipCode { get; set; }

        [DataMember(Name = "geo")]
        public Geolocation Geolocation { get; set; }
    }

    [DataContract(Name = "geo")]
    public class Geolocation
    {
        [DataMember(Name = "lat")]
        public decimal Latitude { get; set; }

        [DataMember(Name = "lng")]
        public decimal Longitude { get; set; }
    }
}
