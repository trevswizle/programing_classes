class ConstructionWorker : Employee
{
    public ConstructionWorker(string name, double hours, double pay) : base(name, hours, pay)
    {
    }
    public override double Getpay()
    {
        return base.Getpay() + 1000;
    }
}