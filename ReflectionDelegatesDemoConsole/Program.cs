using System.Diagnostics;
using ReflectionDelegatesDemoConsole;

var homeController = new HomeController();
var homeControllerType = homeController.GetType();
var prop = homeControllerType.GetProperties()
    .FirstOrDefault(pr => pr.IsDefined(typeof(DataAttribute), true));

var propGetMethod = prop.GetMethod;

var stopwatch = Stopwatch.StartNew();
for (var i = 0; i < 1000000; i++)
{
    var dict = (IDictionary<string, string>)propGetMethod.Invoke(homeController, Array.Empty<object>());
}

Console.WriteLine($"Reflection method speed performance: {stopwatch.Elapsed.Milliseconds} milliseconds");

stopwatch = Stopwatch.StartNew();
var deleg = PropertyHelper<HomeController>.MakeFastProperty<IDictionary<string, string>>(prop);
for (var i = 0; i < 1000000; i++)
{
    var dict = deleg(homeController);
}

Console.WriteLine($"Delegated method speed performance: {stopwatch.Elapsed.Milliseconds} milliseconds");