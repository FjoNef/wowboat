namespace WowBoatApi.Repository;

public interface IBoatRepository
{
    IEnumerable<BoatInformation> GetAllBoats();
}