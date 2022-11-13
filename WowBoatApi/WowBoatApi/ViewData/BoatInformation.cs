using WowBoatApi.DAL;

namespace WowBoatApi.ViewData;

public class BoatInformationView
{
    public int Id { get; private set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public int MaxCapacity { get; set; }
    
    public int RoomsCount { get; set; }
    
    public string Description { get; set; }
    
    public bool CaptainAvailable { get; set; }
    
    public List<BoatImage> Images { get; set; }
    
    public List<string> Benefits { get; set; }
    
    public int BoatType { get; set; }
    
    public int Location { get; set; }
}