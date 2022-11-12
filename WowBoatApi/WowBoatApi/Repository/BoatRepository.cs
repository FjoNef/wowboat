namespace WowBoatApi.Repository;

public class BoatRepository : IBoatRepository
{
    public IEnumerable<BoatInformation> GetAllBoats()
    {
        return new List<BoatInformation>() { new BoatInformation("Test boat", 34.2)};
    }
}