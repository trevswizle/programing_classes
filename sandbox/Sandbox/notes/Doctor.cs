class Doctor : Employee
{
    private double _salary;
    public Doctor(string name, double salary) : base(name, 0, 0)
    {
        _salary = salary;
    }

    public override double Getpay()
    {
        return _salary / 52;
    }
}