namespace WowBoatApi.DAL;

public class Filters
{
    public Filters(List<string> boatType, List<string>  startLocation, List<string>? endLocation)
    {
        BoatType = boatType;
        StartLocation = startLocation;
        EndLocation = endLocation;
    }

    public List<string> BoatType { get; set; }
    public List<string> StartLocation { get; set; }
    public List<string>? EndLocation { get; set; }
}