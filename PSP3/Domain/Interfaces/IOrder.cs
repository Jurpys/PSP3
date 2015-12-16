namespace PSP3.Domain
{
    public interface IOrder
    {
        int Id { get; set; }
        string Destination { get; set; }
        bool IsTaken { get; set; }
        double? Price { get; set; }
    }
}