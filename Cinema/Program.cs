using Cinema;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    //movie
    Movie movie = new("The Godfather");
    
    //screenings
    MovieScreening screening1 = new(movie, DateTime.Now.AddDays(+11), 10);
    MovieScreening screening2 = new(movie, DateTime.Now.AddDays(+12), 10);
    
    //tickets
    MovieTicket ticket1 = new(screening1, true, 1, 1);
    MovieTicket ticket2 = new(screening1, false, 1, 2);
    MovieTicket ticket3 = new(screening1, true, 1, 3);
    MovieTicket ticket4 = new(screening1, true, 2, 2);
    MovieTicket ticket5 = new(screening1, true, 3, 2);
    MovieTicket ticket6 = new(screening1, true, 4, 2);
    
    //orders
    Order regularOrder = new(1, false);
    Order studentOrder = new(2, true);
    
    //add tickets to orders
    studentOrder.AddSeatReservation(ticket1);
    studentOrder.AddSeatReservation(ticket2);
    studentOrder.AddSeatReservation(ticket3);
    studentOrder.AddSeatReservation(ticket4);
    studentOrder.AddSeatReservation(ticket5);
    studentOrder.AddSeatReservation(ticket6);
    
    //exports
    studentOrder.Export(TicketExportFormat.PLAINTEXT);
    studentOrder.Export(TicketExportFormat.JSON);
    

    return studentOrder.ToString();

});

app.Run();