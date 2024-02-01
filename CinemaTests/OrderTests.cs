using Cinema;

namespace CinemaTests
{
    public class OrderTests
    {
        [Fact]
        public void TotalPrice_NoTickets_ReturnsTotalPriceOfZero()
        {
            // Arrange
            Order order = new Order(1, false); 

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(0, result);
        }
    }
}