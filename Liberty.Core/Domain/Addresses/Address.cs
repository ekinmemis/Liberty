namespace Liberty.Core.Domain.Addresses
{
    public partial class Address : BaseEntity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public int BuildingNumber { get; set; }
        public int FloorNumber { get; set; }
        public int PostCode { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
    }
}
