// 创建一个环境

using planting;
using Environment = planting.Environment;

// 创建一个具有特定魔力属性和土壤成分的环境
Environment gardenEnvironment = new Environment(25.0f, "Loamy");
gardenEnvironment.AdjustMagicAttribute("Light", 80.0f); // 提高光照强度
gardenEnvironment.AdjustSoilComponent("Water", 90.0f); // 提高土壤湿度

// 创建两朵不同种类的花，并赋予它们各自的魔法属性
Flower rose = new Flower("Rose");
rose.AddAttribute(new WindAttribute(60.0f));
rose.AddAttribute(new LightAttribute(70.0f));

Flower lily = new Flower("Lily");
lily.AddAttribute(new WaterAttribute(80.0f)); // 假设有WaterAttribute类
lily.AddAttribute(new EarthAttribute(65.0f)); // 假设有EarthAttribute类

// 让花朵适应环境
rose.AdjustToEnvironment(gardenEnvironment);
lily.AdjustToEnvironment(gardenEnvironment);

// 输出每朵花的当前魔力含量
Console.WriteLine("After adjusting to the environment:");
foreach (var flower in new List<Flower> { rose, lily })
{
    Console.WriteLine($"Flower: {flower.Species}");
    foreach (var magicLevel in flower.MagicLevels)
    {
        Console.WriteLine($"  {magicLevel.Key}: {magicLevel.Value}%");
    }
}

// 杂交花朵
Flower hybrid = Flower.CrossBreed(rose, lily);

// 输出杂交后的花的信息
Console.WriteLine($"Hybrid Flower: {hybrid.Species}");
foreach (var attr in hybrid.Attributes)
{
    attr.ApplyEffect(hybrid);
}

// 让杂交后的花朵也适应环境
hybrid.AdjustToEnvironment(gardenEnvironment);

// 输出杂交后花朵的当前魔力含量
Console.WriteLine("Hybrid flower after adjusting to the environment:");
foreach (var magicLevel in hybrid.MagicLevels)
{
    Console.WriteLine($"  {magicLevel.Key}: {magicLevel.Value}%");
}