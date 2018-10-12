using System.Runtime.Serialization;

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

        //[DataMember(Name = "email")]
        //public string Email { get; set; }

        [IgnoreDataMember()]
        public string _email { get; set; }

        [DataMember(Name = "email")]
        public string EncryptedEmail
        {
            get { return UserSecurityOptions.EncryptEmail ? Utils.SecurityUtils.GetHashFromString(_email) : _email; }
            set { _email = value; }
        }

        [DataMember(Name = "address")]
        public Address Address { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "website")]
        public string Website { get; set; }

        [DataMember(Name = "company")]
        public Company Company { get; set; }
    }
}