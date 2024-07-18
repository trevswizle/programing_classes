using System;

class Menu
{
    public void Showmenu()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Please Select an option:");
            Console.WriteLine("1. Order Here");
            Console.WriteLine("2. View Order, and address");
            Console.WriteLine("3. View Products to buy");
            Console.WriteLine("4. Enter Your Infomation");
            Console.WriteLine("5. Quit");
        }
    }
    
}   
class Order
{
    private Customer _customer;
    private List<Prodoct> _products;
}
class Prodoct
{
    private string _name;
    private string _id;
    private float _price;
    private int _quantity;
}
class Customer
{
    private string _name;
    private Address _address;
}
class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _county;
}