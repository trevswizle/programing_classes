class Circle
{

    private double _radius;
    
    public Circle(Double radius = 0.0)
    {
        _radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    public double GetDiameter()
    {
        return _radius * 2;
    }

    public double GetRadius()
        {
            return _radius;
        }
    
    public void SetRadius(Double radius)
    {
        _radius = radius;
    }
}