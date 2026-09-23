public class Product
{
    private string Name { get; set; }
    private string ProductId { get; set; }
    private double Price { get; set; }
    private int Quantity { get; set; }

    public Product(string name, string productId, double price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetProductId()
    {
        return ProductId;
    }

    public double GetPrice()
    {
        return Price;
    }

    public int GetQuantity()
    {
        return Quantity;
    }

    public double GetTotalCost()
    {
        return Price * Quantity;
    }
}