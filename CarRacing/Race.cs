using CarRacing.Veiculos;

public class Race
{
    private Track _track;
    private Vehicle[] _vehicles;
    private Vehicle _winner = null;

    public Race(Track track, Vehicle[] vehicles)
    {
        _track = track;
        _vehicles = vehicles;
    }

    public Vehicle Start(int delay)
    {
        while (_winner == null)
        {
            _track.MoveCars();
            _track.Print();

            Thread.Sleep(delay);

            _winner = _track.GetWinner();
        }

        return _winner;
    }
}
