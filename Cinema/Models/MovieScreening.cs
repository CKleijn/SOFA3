namespace Cinema.Models
{
    public class MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        private readonly Movie _movie = movie;
        private readonly DateTime _dateAndTime = dateAndTime;
        private readonly double _pricePerSeat = pricePerSeat;
        //private readonly List<MovieTicket> _tickets = [];

        public double GetPricePerSeat() => _pricePerSeat;

        public Movie GetMovie() => _movie;

        public DateTime GetScreeningTime() => _dateAndTime;

        public override string ToString() => $"{_dateAndTime} - a seat costs {_pricePerSeat}";
    }
}
