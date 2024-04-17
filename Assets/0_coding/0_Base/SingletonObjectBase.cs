using UnityEngine;

public class SingletonObjectBase<T> : ObjectBase
    where T : ObjectBase
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            _instance = (T)FindObjectOfType(typeof(T));

            if (_instance == null)
            {
                Debug.LogError(typeof(T) + "is nothing");
            }

            return _instance;
        }
    }

    protected override void Awake()
    {
        if (_instance != null && _instance != this)
        {
            // DebugLogger.LogError(typeof(T) + " is multiple created");
            return;
        }

        _instance = this as T;
    }

    protected override void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
