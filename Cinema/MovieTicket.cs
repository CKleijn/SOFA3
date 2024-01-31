using System.Text;

namespace Cinema
{
    public class MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
    {
        public bool IsPremiumTicket() => isPremiumReservation;

        public double GetPrice() => movieScreening.GetPricePerSeat();
        public DateTime GetScreeningTime() => movieScreening.GetScreeningTime();
        
        public object ToJson()
        {
            return new
            {
                screening = movieScreening.ToJson(),
                isPremium = isPremiumReservation,
                rowNr = seatRow,
                seatNr
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
