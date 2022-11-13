using WowBoatApi.DAL;
using WowBoatApi.ViewData;

namespace WowBoatApi.Repository;

public interface IBoatRepository
{
    IAsyncEnumerable<BoatInformation> GetAllBoats(int page, int pageSize);
    
    IAsyncEnumerable<BoatInformation> GetWithFilters(Filters filters, int page, int pageSize);
    
    Task<BoatInformation?> GetBoat(int boatId);
    
    IAsyncEnumerable<BoatType> GetBoatTypes();
    
    IAsyncEnumerable<BoatLocation> GetBoatLocations();

    Task AddBoat(BoatInformationView boat);
    
    Task AddBoatType(string name);
    
    Task AddBoatLocation(string name);
    Task AddBoatBenefit(string name);
}