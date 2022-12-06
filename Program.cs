string[] cars = { "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
       "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo", "Subaru", "Жигули :)"};

var item = from p in cars
           where p.ToUpper().StartsWith("F")
           select p;
var itemOne = cars.Where(p => p.ToUpper().StartsWith("F")).Select(p => p);
foreach (var it in itemOne)
{
    Console.WriteLine(it);
}