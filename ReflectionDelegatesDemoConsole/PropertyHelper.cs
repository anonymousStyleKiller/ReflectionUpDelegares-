using System.Collections;
using System.Collections.Specialized;
using System.Reflection;

namespace ReflectionDelegatesDemoConsole;

public class PropertyHelper<TClass>
{
    private static readonly HybridDictionary Cache = new();
    public static Func<TClass, TResult> MakeFastProperty<TResult>(PropertyInfo propertyInfo)
    {
        if (Cache.Contains(propertyInfo.Name)) return (Func<TClass, TResult>)Cache[propertyInfo.Name];
        var getMethod = propertyInfo.GetMethod;
        var @delegate = (Func<TClass, TResult>)getMethod.CreateDelegate(typeof(Func<TClass, TResult>));
        Cache.Add(propertyInfo.Name, @delegate);
        return @delegate;
    }
    
}