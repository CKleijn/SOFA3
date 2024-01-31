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

        public bool IsPremiumTicket() => this._isPremium;

        public double GetPrice() => this._movieScreening.GetPricePerSeat();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Ticket info\n");
            sb.AppendLine($"Row number: {this._rowNr}");
            sb.AppendLine($"Seat number: {this._seatNr}");
            sb.AppendLine($"Seat type: {(this._isPremium ? "Premium" : "Basic")}");
            sb.AppendLine($"Price: {this.GetPrice()}");

            return sb.ToString();
        } 
    } 
}
