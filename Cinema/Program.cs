using Cinema;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    //movie
    Movie movie = new("The Godfather");
    
    //screenings
    MovieScreening screening = new(movie, DateTime.Now.AddDays(+10), 10);
    
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
    
    //add tickets to orders
    order.AddSeatReservation(ticket1);
    order.AddSeatReservation(ticket2);
    order.AddSeatReservation(ticket3);
    order.AddSeatReservation(ticket4);
    order.AddSeatReservation(ticket5);
    order.AddSeatReservation(ticket6);
    
    //exports
    order.Export(TicketExportFormat.PLAINTEXT);
    order.Export(TicketExportFormat.JSON);

    return order.ToString();
});

app.Run();