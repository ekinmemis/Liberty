namespace Liberty.Web.Models.AddressModels
{
    public class AddressModel
    {
        public int Id { get; set; }
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