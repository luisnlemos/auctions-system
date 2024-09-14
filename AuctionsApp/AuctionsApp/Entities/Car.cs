namespace AuctionsApp.Entities
{
    public abstract class Car
    {
        public Guid Id 
        { 
            get => Id; 
            private set => Id = Guid.NewGuid(); 
        }
        public int Type { get; private set; }
        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public decimal StartingBid { get; private set; }

        public Car(int type, string manufacturer, string model, int year, decimal startingBid)
        {
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
            Year = year;
            StartingBid = startingBid;
        }

    }
}
