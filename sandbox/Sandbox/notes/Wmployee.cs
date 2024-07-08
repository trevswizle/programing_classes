class Employee
{
    private string _name;

    private double _hoursWorked;

    private double _hourlyWage;

    public Employee(string name, double hoursWorked, double hourlywage)
    {
        _name = name;
        _hoursWorked = hoursWorked;
        _hourlyWage = hourlywage;
    }
    public virtual double Getpay()
    {
        return _hoursWorked * _hourlyWage;
    }
    public string Getname()
    {
        return _name;
    }
}