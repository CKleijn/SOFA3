using Cinema;

namespace CinemaTests
{
    public class OrderTests
    {
        [Fact]
        public void TotalPrice_NoTickets_ReturnsTotalPriceOf0()
        {
            // Arrange
            Order order = new(1, false); 

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void TotalPrice_SixNormalTicketsWithoutStudentStatusForSaturday_ReturnsTotalPriceOf54()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, false, 1, 1);
            MovieTicket ticket2 = new(screening, false, 1, 2);
            MovieTicket ticket3 = new(screening, false, 1, 3);
            MovieTicket ticket4 = new(screening, false, 2, 2);
            MovieTicket ticket5 = new(screening, false, 3, 2);
            MovieTicket ticket6 = new(screening, false, 4, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);
            order.AddSeatReservation(ticket5);
            order.AddSeatReservation(ticket6);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(54, result);
        }

        [Fact]
        public void TotalPrice_FiveNormalTicketsWithoutStudentStatusForSaturday_ReturnsTotalPriceOf50()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, false, 1, 1);
            MovieTicket ticket2 = new(screening, false, 1, 2);
            MovieTicket ticket3 = new(screening, false, 1, 3);
            MovieTicket ticket4 = new(screening, false, 2, 2);
            MovieTicket ticket5 = new(screening, false, 3, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);
            order.AddSeatReservation(ticket5);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(50, result);
        }

        [Fact]
        public void TotalPrice_SixPremiumTicketsWithoutStudentStatusForSaturday_ReturnsTotalPriceOf70dot20()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);
            MovieTicket ticket3 = new(screening, true, 1, 3);
            MovieTicket ticket4 = new(screening, true, 2, 2);
            MovieTicket ticket5 = new(screening, true, 3, 2);
            MovieTicket ticket6 = new(screening, true, 4, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);
            order.AddSeatReservation(ticket5);
            order.AddSeatReservation(ticket6);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(70.20, result);
        }

        [Fact]
        public void TotalPrice_TwoPremiumTicketsWithStudentStatusForSaturday_ReturnsTotalPriceOf12()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, true);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(12, result);
        }

        [Fact]
        public void TotalPrice_TwoPremiumTicketsWithoutStudentStatusForSaturday_ReturnsTotalPriceOf26()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(26, result);
        }
    }
}