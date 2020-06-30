using Liberty.Core;
using Liberty.Core.Domain.Addresses;
using Liberty.Data.Infrastructure;
using Liberty.Data.Repository;
using System;
using System.Linq;

namespace Liberty.Services.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDatabaseFactory _databaseFactory;

        public AddressService()
        {
            this._databaseFactory = new DatabaseFactory();
            this._addressRepository = new Repository<Address>();
            this._unitOfWork = new UnitOfWork(_databaseFactory);
        }

        public virtual IPagedList<Address> GetAllAddress(string name = null, int pageIndex = 0, int pageSize = 0)
        {
            var query = _addressRepository.Table;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            query = query.OrderBy(o => o.Id);

            var addresss = new PagedList<Address>(query, pageIndex, pageSize);

            return addresss;
        }

        public virtual void DeleteAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address");

            _addressRepository.Delete(address);
        }

        public virtual Address GetAddressById(int addressId)
        {
            if (addressId == 0)
                return null;

            return _addressRepository.GetById(addressId);
        }

        public virtual void InsertAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address");

            _addressRepository.Insert(address);
        }

        public virtual void UpdateAddress(Address address)
        {
            if (address == null)
                throw new ArgumentNullException("address");

            _addressRepository.Update(address);
        }

        public void SaveAddress()
        {
            _unitOfWork.Save();
        }
    }
}
