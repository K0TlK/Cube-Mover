using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<T>();
                if (!instance)
                {
                    Debug.LogError($"Singleton of type {typeof(T)} not contains in scene");
                    return null;
                }

                instance.AwakeSingletone();
            }
            
            return instance;
        }
    }

    public static bool InstanceIsNotNull => instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = GetComponent<T>();
            AwakeSingletone();
        }
        else
        {
            Debug.LogError($"Dublicated singleton instance {nameof(T)}", this);
        }
    }  

    /// <summary>
    /// Default <see cref="Awake"/>
    /// </summary>
    protected virtual void AwakeSingletone() { }
}