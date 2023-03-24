using ExampleClassLibrary;

List<Address> addresses = new()
{
    new Address() { City = "Moscow" },
    new Address() { City = "Orel" },
    new Address() { City = "Tula" },
    new Address() { City = "Kaluga" },
};

var users = new List<User>()
{
    new("Sam", 35, addresses[0]),
    new("Bob", 31, addresses[1]),
    new("Tim", 29, addresses[2]),
    new("Joe", 42, addresses[1]),
    new("Leo", 35, addresses[0]),
    new("Tom", 41, addresses[3]),
    new("Bill", 19, addresses[0]),
    new("Ann", 35, addresses[2]),
    new("Poul", 24, addresses[3]),
    new("Leo", 30, addresses[0]),
    new("Phill", 37, addresses[2]),
    new("Elisa", 25, addresses[0]),
};

var usersGroupO = from u in users
                  group u by u.Address.City;

var usersCityGroupO = from u in users
                      group u by u.Address.City into dg
                      select new
                      {
                          City = dg.Key,
                          Count = dg.Count()
                      };

var usersCityGroupM = users.GroupBy(u => u.Address.City)
                            .Select(dg => new
                            {
                                City = dg.Key,
                                Count = dg.Count()
                            });


var usersGroupM = users.GroupBy(u => u.Address.City);



//foreach(var city in usersGroupM)
//{
//    Console.WriteLine(city.Key);
//    foreach(var user in city)
//        Console.WriteLine($"\tUser name: {user.Name}, age: {user.Age}");
//    Console.WriteLine();
//}

//foreach(var item in usersCityGroupM)
//    Console.WriteLine($"Citi name: {item.City}, Count = {item.Count}");


var usersGroupAllO = from u in users
                     group u by u.Address.City into dg
                     select new
                     {
                         City = dg.Key,
                         Count = dg.Count(),
                         Users = from uu in dg select uu
                     };

var usersGroupAllM = users.GroupBy(u => u.Address.City)
                            .Select(dg => new
                            {
                                City = dg.Key,
                                Count = dg.Count(),
                                Users = dg.Select(uu => uu)
                            });


foreach (var item in usersGroupAllM)
{
    Console.WriteLine($"City Name: {item.City}, count = {item.Count}");
    foreach (var user in item.Users)
        Console.WriteLine($"\tUser name: {user.Name}, age: {user.Age}");
    Console.WriteLine();
}