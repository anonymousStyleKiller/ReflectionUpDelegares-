using System.Reflection;

namespace ReflectionDelegatesDemoConsole;

public class PropertyHelper<TClass>
{
    public static Func<TClass, TResult> MakeFastProperty<TResult>(PropertyInfo propertyInfo)
    {
        var getMethod = propertyInfo.GetMethod;
        var @delegate = (Func<TClass, TResult>)getMethod.CreateDelegate(typeof(Func<TClass, TResult>));
        return @delegate;
    }
    
}