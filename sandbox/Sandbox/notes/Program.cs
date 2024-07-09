using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        

        // Employee employee = new Employee("bob", 40, 23.77);

        // Console.WriteLine($"{employee.Getname()} is due: {employee.Getpay()}");
        
        ConstructionWorker constructionWorker = new ConstructionWorker("betty", 40, 35.88);
        Console.WriteLine($"{constructionWorker.Getname()} is due: {constructionWorker.Getpay()}");

        Doctor doctor = new Doctor("Belinda", 240000.99);
        Console.WriteLine($"{doctor.Getname()} is due: {doctor.Getpay()}");

        List<Employee> employees= new List<Employee>();
        // employees.Add(employee);
        employees.Add(constructionWorker);
        employees.Add(doctor);

        foreach (Employee e in employees)
        {
            Console.WriteLine($"{e.Getname()} is due: {e.Getpay()}");
        }
        
    }
}