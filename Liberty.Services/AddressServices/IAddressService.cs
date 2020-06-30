using Liberty.Core;
using Liberty.Core.Domain.Addresses;

namespace Liberty.Services.AddressServices
{
    public partial interface IAddressService
    {
        IPagedList<Address> GetAllAddress(string name = null,int pageIndex = 0, int pageSize = int.MaxValue);

        void DeleteAddress(Address address);

        Address GetAddressById(int addressId);

        void InsertAddress(Address address);

        void UpdateAddress(Address address);
    }
}
