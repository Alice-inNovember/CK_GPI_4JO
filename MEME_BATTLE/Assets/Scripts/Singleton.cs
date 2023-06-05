public class Singleton<T> where T : class, new()
{
    static T _instance = null;
    public static T Instance => _instance ??= new T();
}