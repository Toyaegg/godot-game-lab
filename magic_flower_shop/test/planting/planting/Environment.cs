namespace planting;

public class Environment
{
    public float Temperature { get; set; }
    public string SoilType { get; set; }
    public Dictionary<string, float> SoilComponents { get; private set; } = new Dictionary<string, float>();
    public Dictionary<string, float> MagicAttributes { get; private set; } = new Dictionary<string, float>();

    public Environment(float temperature, string soilType)
    {
        Temperature = temperature;
        SoilType = soilType;
        InitializeSoilComponents();
        InitializeMagicAttributes();
    }

    private void InitializeSoilComponents()
    {
        // 初始化土壤成分，例如水分、营养物质等
        SoilComponents.Add("Water", 50.0f); // 水分含量
        SoilComponents.Add("Nutrients", 75.0f); // 营养物质含量
        // 可以添加更多成分...
    }

    private void InitializeMagicAttributes()
    {
        // 初始化环境中的魔力属性，如风、光、暗等
        var magicElements = new List<string>
        {
            "Wind", "Light", "Darkness", "Poison", "Fire", "Water", "Ice", "Earth"
        };
        foreach (var element in magicElements)
        {
            MagicAttributes[element] = 50.0f; // 默认值为50%
        }
    }

    // 允许调整环境中的魔力属性或土壤成分
    public void AdjustMagicAttribute(string attribute, float value)
    {
        if (MagicAttributes.ContainsKey(attribute))
        {
            MagicAttributes[attribute] = Math.Max(0, Math.Min(100, value));
        }
    }

    public void AdjustSoilComponent(string component, float value)
    {
        if (SoilComponents.ContainsKey(component))
        {
            SoilComponents[component] = Math.Max(0, Math.Min(100, value));
        }
    }
}
