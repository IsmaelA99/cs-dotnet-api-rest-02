using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSApiRestPractice02.Domain {

    [Table("address")]
    public class Address {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("addressId")]
        [Required]
        public int AddressId { get;  set; }

        [Required]
        [Column("street")]
        public string Street { get; set; }

        [Required]
        [Column("postalCode")]
        public int PostalCode { get; set; }

        [Required]
        [Column("province")]
        public string Province { get; set; }

        [Required]
        [Column("country")]
        public string Country { get; set; }

        [Column("phone")]
        public int Phone { get; set; }

        public Address() {

        }

        public Address(int addressId) {

            AddressId = addressId;

        }

        public Address(int addressId, string street, int postalCode, string province, string country, int phone) {

            AddressId = addressId;
            Street = street;
            PostalCode = postalCode;
            Province = province;
            Country = country;
            Phone = phone;

        }

        public Address(string street, int postalCode, string province, string country, int phone) {

            Street = street;
            PostalCode = postalCode;
            Province = province;
            Country = country;
            Phone = phone;

        }

        public Address(int addressId, string street, int postalCode, string province, string country) {

            AddressId = addressId;
            Street = street;
            PostalCode = postalCode;
            Province = province;
            Country = country;

        }

        public override bool Equals(object? obj) {

            return obj is Address address &&
                   AddressId == address.AddressId &&
                   Street == address.Street &&
                   PostalCode == address.PostalCode &&
                   Province == address.Province &&
                   Country == address.Country &&
                   Phone == address.Phone;

        }

        public override int GetHashCode() {

            return HashCode.Combine(AddressId, Street, PostalCode, Province, Country, Phone);

        }

    }

}
