

public class Singlaton<T> where T : class, new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }

    public Singlaton()
    {
        OnCreateInstance();
    }

    public virtual void OnCreateInstance()
    {
        
    }
}