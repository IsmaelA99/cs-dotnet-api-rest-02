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
        public string province { get; set; }

        [Required]
        [Column("country")]
        public string country { get; set; }

        [Column("phone")]
        public int phone { get; set; }

    }

}
