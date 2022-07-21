namespace AdminDashboard.Api.Data.DTO
{
    public class AddressDTO
    {
		public int AddressID { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public int StateID { get; set; }
		public string? CountryName { get; set; }
		public string? StateName { get; set; }
		public string PostalCode { get; set; }
		public int CountryID { get; set; }
		public int CreatedByID { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
