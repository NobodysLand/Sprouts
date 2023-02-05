abstract class BaseCard
{
    protected int attack = 0;
    protected int defense = 0;
    protected int hitPoints = 0;
    protected int[] cost;
    
    public abstract void Initialize();
    // public abstract int DamageMod();
    public abstract int TakeDamage(int damage);

    public abstract int HP { get; }
    public abstract int Attack { get; }
    public abstract int Defense { get; }
    public abstract int[] Cost { get; }

}