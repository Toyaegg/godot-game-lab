namespace planting;

public class Flower
{
    public string Species { get; private set; }
    public List<FlowerAttribute> Attributes { get; private set; } = new List<FlowerAttribute>();
    public Dictionary<string, float> MagicLevels { get; private set; } = new Dictionary<string, float>();

    public Flower(string species)
    {
        Species = species;
        InitializeMagicLevels();
    }

    private void InitializeMagicLevels()
    {
        var magicElements = new List<string> { "Wind", "Light", "Darkness", "Poison", "Fire", "Water", "Ice", "Earth" };
        foreach (var element in magicElements)
        {
            MagicLevels[element] = 0.0f; // 初始魔力含量为0
        }
    }

    public void AddAttribute(FlowerAttribute attribute)
    {
        Attributes.Add(attribute);
        attribute.ApplyEffect(this);

        if (attribute is MagicAttribute magicAttr)
        {
            MagicLevels[magicAttr.Element] += magicAttr.Power;
        }
    }

    // 杂交方法
    public static Flower CrossBreed(Flower parent1, Flower parent2)
    {
        var child = new Flower($"{parent1.Species}-{parent2.Species}");

        // 简化版：随机选择父母的属性
        Random rand = new Random();
        foreach (var attr in parent1.Attributes)
        {
            if (rand.Next(2) == 0)
            {
                child.AddAttribute(attr);
            }
        }

        foreach (var attr in parent2.Attributes)
        {
            if (rand.Next(2) == 0)
            {
                child.AddAttribute(attr);
            }
        }

        return child;
    }

    // 根据环境调整魔力含量
    public void AdjustToEnvironment(Environment environment)
    {
        foreach (var attr in MagicLevels.Keys)
        {
            if (environment.MagicAttributes.ContainsKey(attr))
            {
                MagicLevels[attr] += environment.MagicAttributes[attr] * 0.01f; // 假设环境影响系数为1%
            }
        }

        foreach (var component in environment.SoilComponents)
        {
            // 这里可以根据土壤成分调整花朵的生长状态或其他属性
            Console.WriteLine($"{Species} grows better with {component.Key} at {component.Value}%.");
        }
    }
}