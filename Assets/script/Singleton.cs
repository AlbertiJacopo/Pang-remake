using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{

    public static T instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            if (!TryGetComponent<T>(out instance))
            {
                instance = gameObject.AddComponent<T>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
