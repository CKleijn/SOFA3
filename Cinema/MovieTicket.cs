using System.Text;

namespace Cinema
{
    public class MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        private MovieScreening _movieScreening = movieScreening;
        private bool _isPremiumReservation = isPremiumReservation;
        private int _seatRow = seatRow;
        private int _seatNr = seatNr;
        
        public bool IsPremiumTicket() => isPremiumReservation;
        
        public double GetPrice() => _movieScreening.GetPricePerSeat();
        
        public DateTime GetScreeningTime() => _movieScreening.GetScreeningTime();
        
        public object ToJson()
        {
            return new
            {
                screening = _movieScreening.ToJson(),
                isPremium = _isPremiumReservation,
                rowNr = _seatRow,
                seatNr = _seatNr
            };
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Movie title: {movieScreening.GetMovie().GetTitle()}");
            sb.AppendLine($"Screening time: {movieScreening.GetScreeningTime().ToString("dd/MM/yyyy HH:mm")}");
            sb.AppendLine($"Row number: {seatRow}");
            sb.AppendLine($"Seat number: {seatNr}");
            sb.AppendLine($"Seat type: {(isPremiumReservation ? "Premium" : "Basic")}");

            return sb.ToString();
        } 
    } 
}
