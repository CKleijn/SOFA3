using System.Text;

namespace Cinema
{
    public class MovieTicket
    {
        private MovieScreening _movieScreening;
        private bool _isPremium;
        private int _rowNr;
        private int _seatNr;

        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
        {
            _movieScreening = movieScreening;
            _isPremium = isPremiumReservation;
            _rowNr = seatRow;
            _seatNr = seatNr;
        }

        public bool IsPremiumTicket() => _isPremium;

        public double GetPrice() => _movieScreening.GetPricePerSeat();
        public DateTime GetScreeningTime() => _movieScreening.GetScreeningTime();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Movie title: {_movieScreening.GetMovie().GetTitle()}");
            sb.AppendLine($"Screening time: {_movieScreening.GetScreeningTime().ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"Row number: {_rowNr}");
            sb.AppendLine($"Seat number: {_seatNr}");
            sb.AppendLine($"Seat type: {(_isPremium ? "Premium" : "Basic")}");

            return sb.ToString();
        } 
    } 
}
