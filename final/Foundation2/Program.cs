using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.ShowMenu();
    }
}

class Menu
{
    private List<Product> _productCatalog;
    private Order _order;
    private Customer _customer;

    public Menu()
    {
        _productCatalog = new List<Product>
        {
            new Product("Laptop", "101", 999.99f, 0),
            new Product("Smartphone", "102", 499.99f, 0),
            new Product("Tablet", "103", 299.99f, 0)
        };
    }

    public void ShowMenu()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nPlease Select an option:");
            Console.WriteLine("1. Order Here");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. View Order and Address");
            Console.WriteLine("4. View Products to Buy");
            Console.WriteLine("5. Enter Your Information");
            Console.WriteLine("6. Quit");

            string userinput = Console.ReadLine();
            switch (userinput)
            {
                case "1":
                    OrderHere();
                    break;
                case "2":
                    ViewCart();
                    break;
                case "3":
                    ViewOrderAndAddress();
                    break;
                case "4":
                    ViewProductsToBuy();
                    break;
                case "5":
                    EnterYourInformation();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    private void OrderHere()
    {
        if (_customer == null)
        {
            Console.WriteLine("Please enter your information first.");
            return;
        }

        Console.WriteLine("Available Products:");
        for (int i = 0; i < _productCatalog.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_productCatalog[i]}");
        }

        Console.Write("Enter the number of the product you want to buy: ");
        int productNumber;
        if (int.TryParse(Console.ReadLine(), out productNumber) && productNumber > 0 && productNumber <= _productCatalog.Count)
        {
            Console.Write("Enter the quantity: ");
            int quantity;
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
            {
                Product selectedProduct = _productCatalog[productNumber - 1];
                _order.AddProduct(new Product(selectedProduct.Name, selectedProduct.ProductID, selectedProduct.PricePerUnit, quantity));
                Console.WriteLine("Product added to the order successfully.");
            }
            else
            {
                Console.WriteLine("Invalid quantity.");
            }
        }
        else
        {
            Console.WriteLine("Invalid product number.");
        }
    }

    private void ViewCart()
    {
        if (_order != null && _order.HasProducts())
        {
            _order.DisplayOrder();
        }
        else
        {
            Console.WriteLine("Your cart is empty.");
        }
    }

    private void ViewOrderAndAddress()
    {
        if (_order != null)
        {
            _order.DisplayOrder();
            Console.WriteLine(_order.GetPackingLabel());
            Console.WriteLine(_order.GetShippingLabel());
        }
        else
        {
            Console.WriteLine("No order has been placed.");
        }
    }

    private void ViewProductsToBuy()
    {
        Console.WriteLine("Available Products:");
        foreach (var product in _productCatalog)
        {
            Console.WriteLine(product);
        }
    }

    private void EnterYourInformation()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your street address: ");
        string street = Console.ReadLine();

        Console.Write("Enter your city: ");
        string city = Console.ReadLine();

        Console.Write("Enter your state: ");
        string state = Console.ReadLine();

        Console.Write("Enter your country: ");
        string country = Console.ReadLine();

        Address address = new Address(street, city, state, country);
        _customer = new Customer(name, address);
        _order = new Order(_customer);

        Console.WriteLine("Customer information entered successfully.");
    }
}

class Product
{
    public string Name { get; private set; }
    public string ProductID { get; private set; }
    public float PricePerUnit { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, string productId, float pricePerUnit, int quantity)
    {
        Name = name;
        ProductID = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    public float TotalCost()
    {
        return PricePerUnit * Quantity;
    }

    public override string ToString()
    {
        return $"Name: {Name}, ID: {ProductID}, Price: {PricePerUnit:C}, Quantity: {Quantity}, Total: {TotalCost():C}";
    }
}

class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

class Customer
{
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }

    public override string ToString()
    {
        return $"{Name}\n{Address}";
    }
}

class Order
{
    private Customer _customer;
    private List<Product> _products;
    private float _shippingCostUSA = 5.0f;
    private float _shippingCostInternational = 35.0f;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public bool HasProducts()
    {
        return _products.Count > 0;
    }

    public float CalculateTotalCost()
    {
        float totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.TotalCost();
        }
        totalCost += _customer.IsInUSA() ? _shippingCostUSA : _shippingCostInternational;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            label += $"{product.Name} ({product.ProductID})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer}";
    }

    public void DisplayOrder()
    {
        Console.WriteLine("Order Details:");
        foreach (var product in _products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine($"Total Cost: {CalculateTotalCost():C}");
    }
}
