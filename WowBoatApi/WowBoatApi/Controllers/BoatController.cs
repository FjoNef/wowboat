using Microsoft.AspNetCore.Mvc;
using WowBoatApi.DAL;
using WowBoatApi.Repository;
using WowBoatApi.ViewData;

namespace WowBoatApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BoatController : ControllerBase
{
    private readonly ILogger<BoatController> _logger;
    private readonly IBoatRepository _boatRepository;

    public BoatController(ILogger<BoatController> logger, IBoatRepository boatRepository)
    {
        _logger = logger;
        _boatRepository = boatRepository;
    }

    [HttpGet("GetAll")]
    public IAsyncEnumerable<BoatInformation> GetAll([FromQuery] int page,[FromQuery] int pageSize)
    {
        return _boatRepository.GetAllBoats(page, pageSize);
    }
    
    [HttpPost("GetBoats")]
    public IAsyncEnumerable<BoatInformation> GetBoats([FromBody] Filters filters, [FromQuery] int page,[FromQuery] int pageSize)
    {
        return _boatRepository.GetWithFilters(filters, page, pageSize);
    }
    
    [HttpGet("GetBoat")]
    public async Task<BoatInformation?> GetBoat([FromQuery] int boatId)
    {
        return await _boatRepository.GetBoat(boatId);
    }
    
    [HttpGet("GetBoatTypes")]
    public IAsyncEnumerable<BoatType> GetBoatTypes()
    {
        return _boatRepository.GetBoatTypes();
    }
    
    [HttpGet("GetBoatLocations")]
    public IAsyncEnumerable<BoatLocation> GetBoatLocations()
    {
        return _boatRepository.GetBoatLocations();
    }
    
    [HttpPost("PostAddBoat")]
    public async Task PostAddBoat([FromBody] BoatInformationView boat)
    {
        await _boatRepository.AddBoat(boat);
    }
    
    [HttpPost("PostAddBoatType")]
    public async Task PostAddBoatType([FromBody] string typeName)
    {
        await _boatRepository.AddBoatType(typeName);
    }
    
    [HttpPost("PostAddBoatLocation")]
    public async Task PostAddBoatLocation([FromBody] string locationName)
    {
        await _boatRepository.AddBoatLocation(locationName);
    }
    
    [HttpPost("PostAddBoatBenefit")]
    public async Task PostAddBoatBenefit([FromBody] string benefitName)
    {
        await _boatRepository.AddBoatBenefit(benefitName);
    }
}