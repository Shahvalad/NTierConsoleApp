using NTierConsoleAppp.Data.Entities;
using NTierConsoleAppp.Data.Repositories;

ADONetRepository<Category> Categoryrepository = new ADONetRepository<Category>();
ADONetRepository<Product> Productrepository = new ADONetRepository<Product>();
//Console.WriteLine(Repository<Category>.GetPropertiesWithout(typeof(Category)));

Categoryrepository.GetAll();