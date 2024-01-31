namespace Cinema
{
    public class Movie
    {
        private string _title;
        private IList<MovieScreening> _screenings;

        public Movie(string title)
        {
            _title = title;
            _screenings = new List<MovieScreening>();
        }

        public void AddScreening(MovieScreening movieScreening) => _screenings.Add(movieScreening);
        
        public string GetTitle() => _title;

        public override string ToString() => $"{_title} - {_screenings.Count} screenings";
    }
}
