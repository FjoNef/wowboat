namespace WowBoatApi.DAL;

public class BoatType
{
    public BoatType(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    
    public string Name { get; set; }
}