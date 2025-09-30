namespace shop;

public class Shelf
{
    public int Id { get; set; }
    public Product Product { get; set; } // 每个货架对应一种产品
    public int Quantity { get; set; } // 货架上的产品数量

    public void AddStock(int quantity)
    {
        if (quantity > 0)
        {
            Quantity += quantity;
        }
    }

    public bool RemoveStock(int quantity)
    {
        if (Quantity >= quantity)
        {
            Quantity -= quantity;
            return true;
        }
        return false;
    }
}