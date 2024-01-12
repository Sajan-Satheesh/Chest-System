
using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
{
    public static T instance { get; private set; }
    protected virtual void Awake()
    {
        if(instance != null && instance != (T)this)
        {
            Destroy(this);
        }
        else
        {
            instance = (T)this;
        }
    }

}
