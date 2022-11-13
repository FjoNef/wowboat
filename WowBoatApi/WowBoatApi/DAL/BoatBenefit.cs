namespace WowBoatApi.DAL;

public class BoatBenefit
{
    public BoatBenefit(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    
    public string Name { get; set; }
    
    public ICollection<BoatInformation> Boats { get; set; }
}