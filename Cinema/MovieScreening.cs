namespace Cinema
{
    public class MovieScreening
    {
        private Movie _movie;
        private DateTime _dateAndTime;
        private double _pricePerSeat;
        private IList<MovieTicket> _tickets;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            _movie = movie;
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
            _tickets = new List<MovieTicket>();
        }

        public double GetPricePerSeat() => _pricePerSeat;
        
        public Movie GetMovie() => _movie;
        
        public DateTime GetScreeningTime() => _dateAndTime;
        
        public override string ToString() => $"{_dateAndTime} - a seat costs {_pricePerSeat}";
    }
}
