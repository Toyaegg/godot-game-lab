namespace planting;

public abstract class FlowerAttribute
{
    public abstract void ApplyEffect(Flower flower);
}

public class ColorAttribute : FlowerAttribute
{
    public string Color { get; set; }

    public ColorAttribute(string color)
    {
        Color = color;
    }

    public override void ApplyEffect(Flower flower)
    {
        Console.WriteLine($"Flower color is now {Color}");
    }
}

public class ScentAttribute : FlowerAttribute
{
    public string Scent { get; set; }

    public ScentAttribute(string scent)
    {
        Scent = scent;
    }

    public override void ApplyEffect(Flower flower)
    {
        Console.WriteLine($"Flower has a {Scent} scent");
    }
}

public abstract class MagicAttribute : FlowerAttribute
{
    public string Element { get; protected set; }
    public float Power { get; protected set; }

    protected MagicAttribute(string element, float power)
    {
        Element = element;
        Power = power;
    }

    public override void ApplyEffect(Flower flower)
    {
        Console.WriteLine($"Flower has a {Power}% power of {Element}.");
    }
}

// 定义具体的魔法属性
public class WindAttribute : MagicAttribute
{
    public WindAttribute(float power) : base("Wind", power) { }
}

public class LightAttribute : MagicAttribute
{
    public LightAttribute(float power) : base("Light", power) { }
}

public class DarknessAttribute : MagicAttribute
{
    public DarknessAttribute(float power) : base("Darkness", power) { }
}

public class PoisonAttribute : MagicAttribute
{
    public PoisonAttribute(float power) : base("Poison", power) { }
}

public class FireAttribute : MagicAttribute
{
    public FireAttribute(float power) : base("Fire", power) { }
}

public class WaterAttribute : MagicAttribute
{
    public WaterAttribute(float power) : base("Water", power) { }
}

public class IceAttribute : MagicAttribute
{
    public IceAttribute(float power) : base("Ice", power) { }
}

public class EarthAttribute : MagicAttribute
{
    public EarthAttribute(float power) : base("Earth", power) { }
}