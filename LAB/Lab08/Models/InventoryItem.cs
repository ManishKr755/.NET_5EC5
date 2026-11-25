
namespace Lab08.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public decimal TotalPrice { get; set; }
    }
}