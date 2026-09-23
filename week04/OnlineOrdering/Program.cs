using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Emily Carter", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "P001", 25.99, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "P002", 89.50, 1));
        order1.AddProduct(new Product("USB-C Hub", "P003", 34.00, 3));

        Address address2 = new Address("45 Rue de la Paix", "Paris", "Ile-de-France", "France");
        Customer customer2 = new Customer("Julien Moreau", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Bluetooth Speaker", "P004", 59.99, 1));
        order2.AddProduct(new Product("Phone Case", "P005", 15.00, 2));

        List<Order> orders = new List<Order> { order1, order2 };

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"===== Order {orderNumber} =====");

            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();

            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();

            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}");
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();

            orderNumber++;
        }
    }
}