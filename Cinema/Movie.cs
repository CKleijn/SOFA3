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

        public void AddScreening(MovieScreening movieScreening) => this._screenings.Add(movieScreening);

        public override string ToString() => $"{this._title} - {this._screenings.Count} screenings";
    }
}
