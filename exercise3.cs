using System.Collections;

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
public class CarCatalog : IEnumerable<Car>
{
    private Car[] cars;
    public CarCatalog(Car[] cars)
    {
        this.cars = cars;
    }
    
    public IEnumerator<Car> GetEnumerator()
    {   
        for (int i = 0; i < cars.Length; i++)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<Car> GetReverseEnumerator()
    {
        for (int i = cars.Length - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }
    
    public IEnumerable<Car> GetCarsByProductionYear(int year)
    {
        foreach (var car in cars)
        {
            if (car.ProductionYear == year)
            {
                yield return car;
            }
        }
    }

    public IEnumerable<Car> GetCarsByMaxSpeed(int speed)
    {
        foreach (var car in cars)
        {
            if (car.MaxSpeed >= speed)
            {
                yield return car;
            }
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program{
    public static void Main(string[] args)
    {
        Car[] cars = {
            new Car("Toyota", 2022, 240),
            new Car("BMW", 2023, 260),
            new Car("Audi", 2024, 270),
            new Car("Mercedes", 2025, 280)
        };
        
        CarCatalog catalog = new CarCatalog(cars);

        Console.WriteLine("Прямой проход:");
        foreach (var car in catalog)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("Обратный проход:");
        foreach (var car in catalog.GetReverseEnumerator())
        {
            Console.WriteLine(car);
        }


        Console.WriteLine("Фильтр по году выпуска:");
        foreach (var car in catalog.GetCarsByProductionYear(2023))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("Фильтр по максимальной скорости:");
        foreach (var car in catalog.GetCarsByMaxSpeed(270))
        {
            Console.WriteLine(car);
        }
    }
    
}