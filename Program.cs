void Print<T>(IEnumerable<T> ts)
{
    foreach (T item in ts)
    {
        Console.Write(item?.ToString() + '|');
    }
    Console.WriteLine();
}

string[] cars = { "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
       "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Жигули :)"};

var item = from p in cars
           where p.ToUpper().StartsWith("F")
           select p;
var itemOne = cars.Where(p => p.ToUpper().StartsWith("F")).Select(p => p);
Print(itemOne);

var indexes = from p in cars
              where Array.IndexOf(cars, p) % 2 == 1
              select p;
Print(indexes);


