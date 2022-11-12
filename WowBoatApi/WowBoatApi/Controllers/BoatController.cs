using Microsoft.AspNetCore.Mvc;
using WowBoatApi.Repository;

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

    [HttpGet]
    public IEnumerable<BoatInformation> GetAll()
    {
        return _boatRepository.GetAllBoats();
    }
}