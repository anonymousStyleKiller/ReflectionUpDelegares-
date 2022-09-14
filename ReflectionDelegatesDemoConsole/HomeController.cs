namespace ReflectionDelegatesDemoConsole;

public class HomeController
{
    public HomeController() => Data = new Dictionary<string, string>
    {
        ["Name"] = "Test",
    };
    
    [Data] 
    public IDictionary<string, string> Data { get; set; }
}