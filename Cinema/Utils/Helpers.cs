namespace Cinema.Utils
{
    public static class Helpers
    {
        public static bool IsWeekend(MovieTicket movieTicket)
        {
            DayOfWeek dayOfWeek = movieTicket.GetScreeningTime().DayOfWeek;
            return dayOfWeek == DayOfWeek.Friday || dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }
    }
}
