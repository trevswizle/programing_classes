using System;

namespace BasicsOfCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Hello World
            Console.WriteLine("Hello, World!");

            // 2. Variables and Data Types
            int integerVariable = 10;
            double doubleVariable = 20.5;
            char charVariable = 'A';
            string stringVariable = "Hello C#";
            bool boolVariable = true;

            Console.WriteLine($"Integer: {integerVariable}, Double: {doubleVariable}, Char: {charVariable}, String: {stringVariable}, Bool: {boolVariable}");

            // 3. Operators
            int a = 10, b = 5;
            Console.WriteLine($"Addition: {a + b}");
            Console.WriteLine($"Subtraction: {a - b}");
            Console.WriteLine($"Multiplication: {a * b}");
            Console.WriteLine($"Division: {a / b}");
            Console.WriteLine($"Modulus: {a % b}");

            // 4. Conditionals
            if (a > b)
            {
                Console.WriteLine("a is greater than b");
            }
            else if (a < b)
            {
                Console.WriteLine("a is less than b");
            }
            else
            {
                Console.WriteLine("a is equal to b");
            }

            // 5. Loops
            // for loop
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"For Loop Iteration: {i}");
            }

            // while loop
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine($"While Loop Iteration: {j}");
                j++;
            }

            // do-while loop
            int k = 0;
            do
            {
                Console.WriteLine($"Do-While Loop Iteration: {k}");
                k++;
            } while (k < 5);

            // 6. Methods
            int sumResult = Add(10, 20);
            Console.WriteLine($"Sum from Add method: {sumResult}");

            // 7. Arrays
            int[] numbers = { 1, 2, 3, 4, 5 };
            foreach (int num in numbers)
            {
                Console.WriteLine($"Array Element: {num}");
            }

            // 8. Classes and Objects
            Person person = new Person("John", 30);
            person.Display();

            // 9. Inheritance
            Student student = new Student("Alice", 20, "Computer Science");
            student.Display();

            // 10. Exception Handling
            try
            {
                int[] arr = new int[5];
                // This will throw an IndexOutOfRangeException
                Console.WriteLine(arr[10]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception caught: " + ex.Message);
            }
        }

        // Method for adding two numbers
        static int Add(int x, int y)
        {
            return x + y;
        }
    }

    // Class and Object Example
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    // Inheritance Example
    class Student : Person
    {
        public string Major { get; set; }

        public Student(string name, int age, string major) : base(name, age)
        {
            Major = major;
        }

    }
}
