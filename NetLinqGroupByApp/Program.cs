using ExampleClassLibrary;

var users = new List<User>()
{
    new("Sam", 35, new Address() { City = "Moscow" }),
    new("Bob", 31, new Address() { City = "Orel" }),
    new("Tim", 29, new Address() { City = "Tula" }),
    new("Joe", 42, new Address() { City = "Orel" }),
    new("Leo", 35, new Address() { City = "Moscow" }),
    new("Tom", 41, new Address() { City = "Kaluga" }),
    new("Bill", 19, new Address() { City = "Moscow" }),
    new("Ann", 35, new Address() { City = "Tula" }),
    new("Poul", 24, new Address() { City = "Kaluga" }),
    new("Leo", 30, new Address() { City = "Moscow" }),
    new("Phill", 37, new Address() { City = "Tula" }),
    new("Elisa", 25, new Address() { City = "Moscow" }),
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