namespace Cinema.Models
{
    public class Movie(string title)
    {
        private readonly string _title = title;
        private readonly List<MovieScreening> _screenings = new();

        public void AddScreening(MovieScreening movieScreening) => _screenings.Add(movieScreening);

        public string GetTitle() => _title;

        public override string ToString() => $"{_title}";
    }
}
