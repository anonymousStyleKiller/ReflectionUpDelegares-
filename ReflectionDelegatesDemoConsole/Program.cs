using System.Reflection;
using ReflectionDelegatesDemoConsole;

var homeController = new HomeController();
var homeControllerType = homeController.GetType();
var prop = homeControllerType.GetProperties()
    .FirstOrDefault(pr => pr.IsDefined(typeof(DataAttribute), true));

var propGetMethod = prop.GetMethod;

var dict = (IDictionary<string, string>)propGetMethod.Invoke(homeController, Array.Empty<object>());

Console.WriteLine(dict["Name"]);
