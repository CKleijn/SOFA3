namespace Cinema
{
    public class MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
    {
        private Movie _movie = movie;
        private DateTime _dateAndTime = dateAndTime;
        private double _pricePerSeat = pricePerSeat;
        private IList<MovieTicket> _tickets = new List<MovieTicket>();

        public double GetPricePerSeat() => _pricePerSeat;
        
        public Movie GetMovie() => _movie;
        
        public DateTime GetScreeningTime() => _dateAndTime;
        
        public override string ToString() => $"{_dateAndTime} - a seat costs {_pricePerSeat}";
    }
}
