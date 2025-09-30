namespace shop;

public class Store
{
    private List<Employee> employees = new List<Employee>();
    private List<Order> orders = new List<Order>();
    private Dictionary<int, Shelf> shelves = new Dictionary<int, Shelf>(); // 使用产品ID作为键

    // Add employee to the store
    public void HireEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    // 创建一个新的订单
    public Order CreateOrder(string customerName, List<Product> products)
    {
        var orderProducts = new List<Product>();

        foreach (var product in products)
        {
            if (shelves.TryGetValue(product.Id, out var shelf) && shelf.RemoveStock(1))
            {
                orderProducts.Add(product);
            }
            else
            {
                Console.WriteLine($"Product {product.Name} is out of stock.");
            }
        }

        if (orderProducts.Count == 0)
        {
            Console.WriteLine("The order cannot be processed due to insufficient stock.");
            return null;
        }

        var order = new Order
        {
            CustomerName = customerName,
            Products = orderProducts
        };
        orders.Add(order);
        return order;
    }

    // 处理现场订单
    public void ProcessOnSiteOrder(Order order)
    {
        if (order != null)
        {
            Console.WriteLine($"Processing on-site order #{order.Id} for {order.CustomerName}");
            // Code to handle on-site order processing
        }
    }

    // 发货远程订单
    public void ShipOrder(Order order, string destinationAddress)
    {
        if (order != null)
        {
            Console.WriteLine($"Shipping order #{order.Id} to {destinationAddress}");
            // Code to handle shipping logistics
        }
    }

    // 向货架添加商品
    public void StockShelf(Product product, int quantity)
    {
        if (shelves.ContainsKey(product.Id))
        {
            shelves[product.Id].AddStock(quantity);
        }
        else
        {
            shelves.Add(product.Id, new Shelf { Id = product.Id, Product = product, Quantity = quantity });
        }
    }

    // 显示所有货架状态
    public void ShowShelfStatus()
    {
        foreach (var shelf in shelves.Values)
        {
            Console.WriteLine($"Shelf for {shelf.Product.Name}: {shelf.Quantity} items available.");
        }
    }
}