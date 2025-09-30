using shop;

Store myStore = new Store();

// 雇佣一些员工
myStore.HireEmployee(new Employee { Id = 1, Name = "Alice", Salary = 3000 });
myStore.HireEmployee(new Employee { Id = 2, Name = "Bob", Salary = 3500 });

// 准备一些产品并添加到货架
List<Product> products = new List<Product>
{
    new Product { Id = 1, Name = "Laptop", Price = 999.99m },
    new Product { Id = 2, Name = "Mouse", Price = 2.99m },
    new Product { Id = 3, Name = "符文", Price = 5.99m },
    new Product { Id = 4, Name = "工具", Price = 8.99m },
    new Product { Id = 5, Name = "恐腌", Price = 7.99m }
};

foreach (var product in products)
{
    myStore.StockShelf(product, 10); // 每种产品初始库存为10
}

// 显示货架状态
myStore.ShowShelfStatus();

// 创建并处理现场订单
Order onSiteOrder = myStore.CreateOrder("John Doe", products);
myStore.ProcessOnSiteOrder(onSiteOrder);

// 创建并发货远程订单
Order remoteOrder = myStore.CreateOrder("Jane Doe", products);
myStore.ShipOrder(remoteOrder, "123 Shipping St, City, Country");

// 再次显示货架状态
myStore.ShowShelfStatus();
