using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerBate<T> : MonoBehaviour where T : MonoBehaviour
{

    public static T instance { get;private set; }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this as T;
        }
        else
            Destroy(gameObject);

    }
    protected virtual void OnDestroy()
    {
       
    }



}
