
using UnityEngine;

public class G_MonoSingleton<T> : MonoBehaviour where T : G_MonoSingleton<T>
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
