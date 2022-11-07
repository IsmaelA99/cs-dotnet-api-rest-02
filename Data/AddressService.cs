using CSApiRestPractice02.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CSApiRestPractice02.Data {

    public class AddressService : DbContext {

        public AddressService(DbContextOptions<AddressService> options): base(options) {

        }

        public DbSet<Address> AddressDao { get; set; }


        public async Task<List<Address>> GetAddresses() {

            List<Address> addresses = AddressDao.Select(select => select).ToList();

            return addresses;

        }

        public async Task<Address> GetAddress(int id) {

            return await AddressDao.FirstOrDefaultAsync(x => x.AddressId == id);

        }

        public async Task<Address> SaveAddress(Address address) {

            Address addressToSave = new Address(
                    address.Street,
                    address.PostalCode,
                    address.Province,
                    address.Country,
                    address.Phone
                );

            EntityEntry<Address> response = await AddressDao.AddAsync(addressToSave);

            await SaveChangesAsync();
            
            return await GetAddress(response.Entity.AddressId);

        }

        public async Task<Address> UpdateAddress(int id, Address address) {

            Address addressToUpdate = new Address(
                    id,
                    address.Street,
                    address.PostalCode,
                    address.Province,
                    address.Country,
                    address.Phone
                );

            AddressDao.Update(addressToUpdate);

            SaveChanges();

            return addressToUpdate;

        }

        public async Task<Boolean> deleteAddress(int id) {

            Address addressToDelete = await GetAddress(id);

            AddressDao.Remove(addressToDelete);

            SaveChanges();

            return true;

        }

    }

}
