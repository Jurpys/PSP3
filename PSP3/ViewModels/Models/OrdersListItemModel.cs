namespace PSP3.ViewModels
{
    public class OrdersListItemModel
    {
        public int Id { get; set; } 
        public string Destination { get; set; } 
        public bool IsTaken { get; set; } 
        public double Price { get; set; } 
    }
}