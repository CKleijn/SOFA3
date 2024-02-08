using Cinema.Implementations.Export;
using Cinema.Implementations.PriceRules;
using Cinema.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    //movie
    Movie movie = new("The Godfather");

    //screenings
    MovieScreening screening = new(movie, new DateTime(2024, 2, 3, 9, 0, 0, DateTimeKind.Local), 10);

    //add screening to movie
    movie.AddScreening(screening);
    
    //tickets
    MovieTicket ticket1 = new(screening, true, 1, 1);
    MovieTicket ticket2 = new(screening, false, 1, 2);
    MovieTicket ticket3 = new(screening, true, 1, 3);
    MovieTicket ticket4 = new(screening, true, 2, 2);
    MovieTicket ticket5 = new(screening, true, 3, 2);
    MovieTicket ticket6 = new(screening, true, 4, 2);
    
    //orders
    Order order = new(1, false);

    //set order's price rules
    order.AddPriceRule(new RegularFreeTicketPriceRuleBehaviour());
    order.AddPriceRule(new RegularPremiumFeePriceRuleBehaviour());
    order.AddPriceRule(new RegularDiscountPriceRuleBehaviour());

    //set export types
    order.AddExportType(new JsonExportBehaviour());
    order.AddExportType(new PlainTextExportBehaviour());

    //add order's tickets
    order.AddSeatReservation(ticket1);
    order.AddSeatReservation(ticket2);
    order.AddSeatReservation(ticket3);
    order.AddSeatReservation(ticket4);
    order.AddSeatReservation(ticket5);
    order.AddSeatReservation(ticket6);
    
    //export
    order.Export();

    return order.ToString();
});

app.Run();