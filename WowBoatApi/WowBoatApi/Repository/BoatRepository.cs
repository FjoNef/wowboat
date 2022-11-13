using Microsoft.EntityFrameworkCore;
using WowBoatApi.DAL;
using WowBoatApi.ViewData;

namespace WowBoatApi.Repository;

public class BoatRepository : IBoatRepository
{
    private readonly WowBoatDbContext _dbContext;

    public BoatRepository(WowBoatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IAsyncEnumerable<BoatInformation> GetAllBoats(int page = 0, int pageSize = 16)
    {
        return _dbContext.BoatsInformation.Skip(page * pageSize).Take(pageSize)
            .Include(b => b.Images)
            .Include(b => b.BoatType)
            .Include(b => b.Location).AsAsyncEnumerable();
    }

    public IAsyncEnumerable<BoatInformation> GetWithFilters(Filters filters, int page = 0, int pageSize = 16)
    {
        var isStartLocationEmpty = !filters.StartLocation.Any();
        var isBoatTypeEmpty = !filters.BoatType.Any();
        return _dbContext.BoatsInformation
            .Where(boat => (isStartLocationEmpty || filters.StartLocation.Contains(boat.Location.Name)) &&
                           (isBoatTypeEmpty || filters.BoatType.Contains(boat.BoatType.Name)))
            .Include(b => b.Images)
            .Include(b => b.BoatType)
            .Include(b => b.Location)
            .Skip(page * pageSize).Take(pageSize).AsAsyncEnumerable();
    }

    public async Task<BoatInformation?> GetBoat(int boatId)
    {
        return await _dbContext.BoatsInformation.FindAsync(boatId);
    }

    public IAsyncEnumerable<BoatType> GetBoatTypes()
    {
        return _dbContext.BoatTypes.AsAsyncEnumerable();
    }

    public IAsyncEnumerable<BoatLocation> GetBoatLocations()
    {
        return _dbContext.BoatLocations.AsAsyncEnumerable();
    }

    public async Task AddBoat(BoatInformationView boat)
    {
        var benefit = _dbContext.BoatBenefits.Where(benefit => boat.Benefits.Contains(benefit.Name)).ToList();
        var boatType = _dbContext.BoatTypes.First(b => b.Id == boat.BoatType);
        var location = _dbContext.BoatLocations.First(b => b.Id == boat.Location);
        var boatInformation = new BoatInformation
        {
            Name = boat.Name,
            Price = boat.Price,
            MaxCapacity = boat.MaxCapacity,
            RoomsCount = boat.RoomsCount,
            Description = boat.Description,
            CaptainAvailable = boat.CaptainAvailable,
            Images = boat.Images,
            Benefits = benefit,
            BoatType = boatType,
            Location = location
        };
        _dbContext.BoatsInformation.Add(boatInformation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddBoatType(string name)
    {
        _dbContext.BoatTypes.Add(new BoatType(name));
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddBoatLocation(string name)
    {
        _dbContext.BoatLocations.Add(new BoatLocation(name));
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddBoatBenefit(string name)
    {
        _dbContext.BoatBenefits.Add(new BoatBenefit(name));
        await _dbContext.SaveChangesAsync();
    }
}