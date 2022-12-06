

using System.Text;

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
/////////////////
var item = from p in cars
           where p.ToUpper().StartsWith("F")
           select p;
var itemOne = cars.Where(p => p.ToUpper().StartsWith("F")).Select(p => p);
Print(itemOne);
Console.WriteLine("-------------------------------------------");
////////////////
var indexes = from p in cars
              where Array.IndexOf(cars, p) % 2 == 1
              select p;
Print(indexes);
Console.WriteLine("-------------------------------------------");
///////////////
var length = from p in cars
             select p.Length;
Print(length);

var length1 = cars.Select(p => p.Length);
Print(length1);
Console.WriteLine("-------------------------------------------");
///////////////
var anonym = from p in cars
             select new
             {
                 Name = p,
                 Length = p.Length
             };
var anonym2 = cars.Select(p => new {Name = p, Length = p.Length});
foreach (var anon in anonym2)
{
    Console.Write($"Name: {anon.Name}, Length: {anon.Length} \n");
}
Console.WriteLine("-------------------------------------------");
//////////////
var anonym3 = from p in cars
              select new
              {
                  Index = Array.IndexOf(cars, p),
                  Length = p.Length
              };
var anonym4 = cars.Select(p => new { Index = Array.IndexOf(cars, p), Length = p.Length });
foreach (var anon in anonym4)
{
    Console.Write($"Name: {anon.Index}, Length: {anon.Length} \n");
}
Console.WriteLine("-------------------------------------------");
/////////////////
/// <summary>
/// Students
/// </summary>

var studentList = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
        new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
        new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
    };

var stud = from s in studentList
           where s.Age > 12 && s.Age < 20
           orderby s.Age descending, s.StudentName
           select s;
var stud2 = studentList.Where(s => s.Age > 12 && s.Age < 20)
    .OrderByDescending(s => s.Age)
    .Select(s => s);
foreach (var st in stud2)
{
    Console.Write($"ID: {st.StudentID}, Name: {st.StudentName}, Age: {st.Age}\n");
}
Console.WriteLine("-------------------------------------------");
//////////////////////////
var grouping = from s in studentList
               group s by s.Age
               into g
               select new
               {
                   Age = g.Key,
                   Count = g.Count(),
                   Name = from p in g select p
               };
foreach (var group in grouping)
{
    Console.WriteLine($"Age: {group.Age}, Count: {group.Count}");
    foreach(var student in group.Name)
    {
        Console.WriteLine(student.ToString());
    }
}

public class Student
{
    public int StudentID { get; set; }
    public string? StudentName { get; set; }
    public int Age { get; set; }
    public override string ToString() =>
        new StringBuilder()
        .Append($"ID: {StudentID}\n")
        .Append($"Name: {StudentName}\n")
        .Append($"Age: {Age}\n")
        .ToString();
}


