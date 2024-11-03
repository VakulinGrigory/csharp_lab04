public class Car
{
    public string Name{ get; set; }
    public int ProductionYear{ get; set; }
    public int MaxSpeed{ get; set; }
    public Car(string name, int year, int maxspeed)
    {
        Name = name;
        ProductionYear = year;
        MaxSpeed = maxspeed;
    }
    
    public override string ToString()
    {
        return $"{Name} - {ProductionYear} - {MaxSpeed} км/ч";
    }
}

public class CarComparer : IComparer<Car>
{
    public enum ComparisonType
    {
        Name, ProductionYear, MaxSpeed
    }
    
    private ComparisonType comparisonType;

    public CarComparer(ComparisonType comparisonType)
    {
        this.comparisonType = comparisonType;
    }
    
    public int Compare(Car x, Car y)
    {
        if (x == null || y == null)
        { 
            throw new ArgumentException("Невозможно сравнить эти объекты");
        }

        switch (comparisonType)
        {
            case ComparisonType.Name:
                return string.Compare(x.Name, y.Name);
            
            case ComparisonType.ProductionYear:
                return x.ProductionYear.CompareTo(y.ProductionYear);
            
            case ComparisonType.MaxSpeed:
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            
            default:
                throw new ArgumentException("Некорректный тип сравнения");
        }
    }
}

class Program
{
    static void Main()
    {
        Car[] cars = {
            new Car("Toyota", 2022, 240),
            new Car("BMW", 2023, 260),
            new Car("Audi", 2024, 270),
            new Car("Mercedes", 2025, 280)
        };
        
        Console.WriteLine("Сортировка по названию:");
        Array.Sort(cars, new CarComparer(CarComparer.ComparisonType.Name));
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
        
        Console.WriteLine("Сортировка по году выпуска:");
        Array.Sort(cars, new CarComparer(CarComparer.ComparisonType.ProductionYear));
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
        
        Console.WriteLine("Сортировка по максимальной скорости:");
        Array.Sort(cars, new CarComparer(CarComparer.ComparisonType.MaxSpeed));
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}