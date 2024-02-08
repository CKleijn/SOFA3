using System.Text;

namespace Cinema.Models
{
    public class MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        private readonly MovieScreening _movieScreening = movieScreening;
        private readonly bool _isPremiumReservation = isPremiumReservation;
        private readonly int _seatRow = seatRow;
        private readonly int _seatNr = seatNr;

        public bool IsPremiumTicket() => _isPremiumReservation;

        public double GetPrice() => _movieScreening.GetPricePerSeat();

        public DateTime GetScreeningTime() => _movieScreening.GetScreeningTime();

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Movie title: {_movieScreening.GetMovie().GetTitle()}");
            sb.AppendLine($"Screening time: {_movieScreening.GetScreeningTime().ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"Row number: {_seatRow}");
            sb.AppendLine($"Seat number: {_seatNr}");
            sb.AppendLine($"Seat type: {(_isPremiumReservation ? "Premium" : "Basic")}");

            return sb.ToString();
        }
    }
}
