namespace WowBoatApi.DAL;

public class BoatInformation
{
    public int Id { get; private set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public int MaxCapacity { get; set; }
    
    public int RoomsCount { get; set; }
    
    public string Description { get; set; }
    
    public bool CaptainAvailable { get; set; }
    
    public ICollection<BoatImage> Images { get; set; }
    
    public ICollection<BoatBenefit> Benefits { get; set; }
    
    public BoatType BoatType { get; set; }
    
    public BoatLocation Location { get; set; }
}