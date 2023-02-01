abstract class BaseCard
{
    protected int attack = 0;
    protected int defense = 0;
    protected int hitPoints = 0;
    
    public abstract void Initialize();
    // public abstract int DamageMod();
    public abstract int TakeDamage(int damage);

    public abstract int HP { get; }
}