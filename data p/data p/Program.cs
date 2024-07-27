// See https://aka.ms/new-console-template for more information
//Topic 1 week 3

Console.WriteLine("Please Enter a Reg number");

string activeUser = Console.ReadLine();

//week 2 task dictionary with objects

Dictionary<string, car> cars = new ();
cars.Add("BD51SMR", new car("Toyota", "Yaris", "BD51SMR", 2001 , 900));
cars.Add("PO23REI", new car("Vauhall", "Astra", "PO23REI", 2023, 2800));
cars.Add("LA60UIO", new car("Toyota", "Corolla", "LA60UIO", 2010, 1300));

cars.ContainsKey(activeUser);

if (cars.ContainsKey(activeUser))
{
    car temp = cars[activeUser];
    Console.WriteLine($"We have found the car, here's the make: {temp.make}");
    Console.WriteLine($"We have found the car, here's the model: {temp.model}");
    Console.WriteLine($"We have found the car, here's the reg: {temp.reg}");
    Console.WriteLine($"We have found the car, here's the year: {temp.year}");
    Console.WriteLine($"We have found the car, here's the year: {temp.price}");
}
else
{
    Console.WriteLine("This number plate was not found in the system");
}

//Week 3 tasks
var cars_r = cars.Where(x => x.make.Contains("Toyota").OrderBy(x => x.year).Select(x => x.price);

foreach (var vehicle in cars_r)
{
    Console.WriteLine(vehicle);
}
//checks if any element in the list matches the given condtion.
var result1 = cars.Any(x => x > 1000);

//Checks if all the elements in the list matches the given condtion.
var result2 = cars.All(x => x < 1000);

Console.WriteLine(result1);
Console.WriteLine(result2);


Console.WriteLine(cars.Max());
Console.WriteLine(cars.Min());
Console.WriteLine(cars.Sum(price));
Console.WriteLine(cars.Average(price));


public class car
{
    public string make;
    public string model;
    public string reg;
    public int year;
    public int price;

    public car(string make, string model, string reg, int year, int price)
                {
                this.make = make;
                this.model = model;
                this.reg = reg;
                this.year = year;
                this.price = price;
                }
 }