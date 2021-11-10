// See https://aka.ms/new-console-template for more information
Pet cat = new("Cat", 10);
Console.WriteLine($"Hello, {cat}!");

record Pet(string Name, int Age);
