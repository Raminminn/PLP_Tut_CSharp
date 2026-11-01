var people = new List<Person>
{
    new() { Name = "Chad", Age = 8 },
    new() { Name = "Kate", Age = 54 },
    new() { Name = "Silky", Age = 12 },
};

var kids = people
    .Where(p => p.Age < 18)
    .Select(p => p.Name)
    .ToList();

Console.WriteLine(string.Join(", ", kids));

class Person
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}