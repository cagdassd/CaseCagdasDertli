namespace Entities.DTOs
{
	public class CreateOrderRequest
	{
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerGSM { get; set; }
		public int ProductId { get; set; }
		public int UnitPrice { get; set; }
		public int Amount { get; set; }
	}
}