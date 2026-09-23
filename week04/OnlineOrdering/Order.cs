using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> Products { get; set; }
    private Customer OrderCustomer { get; set; }

    public Order(Customer customer)
    {
        OrderCustomer = customer;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (Product product in Products)
        {
            total += product.GetTotalCost();
        }

        total += OrderCustomer.LivesInUSA() ? 5 : 35;

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();

        foreach (Product product in Products)
        {
            label.AppendLine($"{product.GetName()} (Product ID: {product.GetProductId()})");
        }

        return label.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"{OrderCustomer.GetName()}\n{OrderCustomer.GetAddress().GetFullAddress()}";
    }
}