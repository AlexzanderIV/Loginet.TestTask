﻿using System.Runtime.Serialization;

namespace Loginet.TestTask.Models
{
    [DataContract(Name = "user")]
    public class User
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string FullName { get; set; }

        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "address")]
        public Address Address { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "website")]
        public string Website { get; set; }

        [DataMember(Name = "company")]
        public Company Company { get; set; }

        public void EncryptEmail()
        {
            Email = Utils.SecurityUtils.GetHashFromString(Email);
        }
    }
}