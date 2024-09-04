namespace FureaApp.Entities
{
	public class SubCategory
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public Guid CategoryId { get; set; }
	}
}