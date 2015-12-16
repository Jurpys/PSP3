namespace PSP3.Domain
{
    public interface ITaxi
    {
        IOrder Order { get; set; }
        int Id { get; set; }

        string DriverName { get; set; }
        void CompleteOrder();

    }
}