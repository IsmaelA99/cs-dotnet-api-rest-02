using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSApiRestPractice02.Domain {

    [Table("customer")]
    public class Customer {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customerId")]
        [Required]
        public int CustomerId { get; set; }

        [Column("address_fk")]
        [Required]
        public Address Address { get; set; }

        [Column("firstName")]
        [Required]
        public string FirstName { get; set; }

        [Column("lastName")]
        public string LastName { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("password")]
        [Required]
        public string Password { get; set; }

        public Customer() {

        }

        public Customer(int customerId) {

            CustomerId = customerId;

        }

        public Customer(int customerId, Address address, string firstName, string lastName, string email, string password) {
            CustomerId = customerId;
            Address = address;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public Customer(int customerId, Address address, string firstName, string email, string password) {

            CustomerId = customerId;
            Address = address;
            FirstName = firstName;
            Email = email;
            Password = password;

        }

        public override bool Equals(object? obj) {

            return obj is Customer customer &&
                   CustomerId == customer.CustomerId &&
                   EqualityComparer<Address>.Default.Equals(address, customer.address) &&
                   FirstName == customer.FirstName &&
                   LastName == customer.LastName &&
                   Email == customer.Email &&
                   Password == customer.Password;

        }

        public override int GetHashCode() {

            return HashCode.Combine(CustomerId, Address, FirstName, LastName, Email, Password);

        }

    }

}
