namespace Cinema
{
    public class Movie(string title)
    {
        private string _title = title;
        private IList<MovieScreening> _screenings = new List<MovieScreening>();

        public void AddScreening(MovieScreening movieScreening) => _screenings.Add(movieScreening);
        
        public string GetTitle() => _title;
        
        public override string ToString() => $"{_title}";
    }
}
