using Cinema.Models;
using Cinema.States.Implementations;

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

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

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

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

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

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

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

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

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

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

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

        [Fact]
        public void SubmitOrder_GivenTwoTickets_WhenCurrentStateIsInitialState_ThenNewStateIsSubmittedState ()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            // Act
            order.SubmitOrder();

            // Assert
            Assert.IsType<SubmittedState>(order.GetState());
        }

        [Fact]
        public void SubmitOrder_GivenZeroTickets_WhenCurrentStateIsInitialState_ThenStateStaysInitialState()
        {
            // Arrange
            Order order = new(1, false);

            // Act
            order.SubmitOrder();

            // Assert
            Assert.IsType<InitialState>(order.GetState());
        }

        [Fact]
        public void EditOrder_GivenTwoTickets_WhenCurrentStateIsSubmittedState_ThenNewStateIsEditState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new SubmittedState(order));

            // Act
            order.EditOrder();

            // Assert
            Assert.IsType<EditState>(order.GetState());
        }

        [Fact]
        public void CancelOrder_GivenTwoTickets_WhenCurrentStateIsSubmittedState_ThenNewStateIsCancelledState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new SubmittedState(order));

            // Act
            order.CancelOrder();

            // Assert
            Assert.IsType<CancelledState>(order.GetState());
        }

        [Fact]
        public void ProvisionOrder_GivenTwoTicketsAndScreeningTimeIsInsideTwentyFourHoursOfTheScreeningTime_WhenCurrentStateIsSubmittedState_ThenNewStateIsProvisionalState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, DateTime.Now.AddHours(23), 10);

            movie.AddScreening(screening);
            
            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new SubmittedState(order));

            // Act
            order.ProvisionOrder();

            // Assert
            Assert.IsType<ProvisionalState>(order.GetState());
        }

        [Fact]
        public void ProvisionOrder_GivenTwoTicketsAndScreeningTimeIsOutsideTwentyFourHoursOfTheScreeningTime_WhenCurrentStateIsSubmittedState_ThenStateStaysSubmittedState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, DateTime.Now.AddHours(48), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new SubmittedState(order));

            // Act
            order.ProvisionOrder();

            // Assert
            Assert.IsType<SubmittedState>(order.GetState());
        }

        [Fact]
        public void PayOrder_GivenTwoTickets_WhenCurrentStateIsSubmittedState_ThenNewStateIsPaidState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 4, 20, 9, 0, 0, DateTimeKind.Local), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new SubmittedState(order));

            // Act
            order.PayOrder();

            // Assert
            Assert.IsType<PaidState>(order.GetState());
        }

        [Fact]
        public void SubmitOrder_GivenTwoTickets_WhenCurrentStateIsEditState_ThenNewStateIsSubmittedState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new EditState(order));

            // Act
            order.SubmitOrder();

            // Assert
            Assert.IsType<SubmittedState>(order.GetState());
        }

        [Fact]
        public void SubmitOrder_GivenZeroTickets_WhenCurrentStateIsEditState_ThenStateStaysEditState()
        {
            // Arrange
            Order order = new(1, false);

            order.SetState(new EditState(order));

            // Act
            order.SubmitOrder();

            // Assert
            Assert.IsType<EditState>(order.GetState());
        }

        [Fact]
        public void CancelOrder_GivenTwoTickets_WhenCurrentStateIsProvisionalState_ThenNewStateIsCancelledState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new ProvisionalState(order));

            // Act
            order.CancelOrder();

            // Assert
            Assert.IsType<CancelledState>(order.GetState());
        }

        [Fact]
        public void ProvisionOrder_GivenTwoTicketsAndScreeningTimeIsInsideTwelveHoursOfTheScreeningTime_WhenCurrentStateIsProvisionalState_ThenNewStateIsCancelledState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, DateTime.Now.AddHours(5), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new ProvisionalState(order));

            // Act
            order.ProvisionOrder();

            // Assert
            Assert.IsType<CancelledState>(order.GetState());
        }

        [Fact]
        public void ProvisionOrder_GivenTwoTicketsAndScreeningTimeIsOutsideTwelveHoursOfTheScreeningTime_WhenCurrentStateIsProvisionalState__ThenStateStaysProvisionalState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, DateTime.Now.AddHours(14), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new ProvisionalState(order));

            // Act
            order.ProvisionOrder();

            // Assert
            Assert.IsType<ProvisionalState>(order.GetState());
        }

        [Fact]
        public void PayOrder_GivenTwoTickets_WhenCurrentStateIsProvisionalState_ThenNewStateIsPaidState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 4, 20, 9, 0, 0, DateTimeKind.Local), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new ProvisionalState(order));

            // Act
            order.PayOrder();

            // Assert
            Assert.IsType<PaidState>(order.GetState());
        }

        [Fact]
        public void FinalizeOrder_GivenTwoTickets_WhenCurrentStateIsPaidState_ThenNewStateIsFinalizedState()
        {
            // Arrange
            Movie movie = new("The Godfather");

            MovieScreening screening = new(movie, new DateTime(2024, 4, 20, 9, 0, 0, DateTimeKind.Local), 10);

            movie.AddScreening(screening);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 1, 2);

            Order order = new(1, false);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            order.SetState(new PaidState(order));

            // Act
            order.FinalizeOrder();

            // Assert
            Assert.IsType<FinalizedState>(order.GetState());
        }
    }
}