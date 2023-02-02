abstract class BaseTerritory
{
    public enum ResouceType
    {
        Water,
        Potassium,
        Phosphorus,
        Nitrogen
    }
    protected string name;
    protected string flavorText;
    protected ResouceType resourceType;
    protected int resourceTotal;
    protected int resourceRate;
    protected float hitPoints;
    protected float timeToTake;
    
    public abstract void Initialize();
    // public abstract int DamageMod();
    public abstract bool ResolveCombat(int damage);

    public abstract void GenerateResource();

    public abstract int ResourceRate { get; }

    public abstract int ResourceTotal { get; }

    public abstract int ResourceType { get; }
}