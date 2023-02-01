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
    protected int hitPoints;
    protected int timeToTake;
    
    public abstract void Initialize();
    // public abstract int DamageMod();
    public abstract bool ResolveCombat(int damage);

    public abstract void ManageResource();

    // public abstract int HP { get; }
}