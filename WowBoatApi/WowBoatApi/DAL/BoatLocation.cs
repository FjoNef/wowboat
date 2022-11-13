namespace WowBoatApi.DAL;

public class BoatLocation
{
    public BoatLocation(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    
    public string Name { get; set; }
}