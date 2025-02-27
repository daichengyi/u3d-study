using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//单例模式
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance{
        get => instance;
    }

    protected virtual void Awake(){
        if(instance == null){
            instance  = this as T;
        }else{
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy(){
        if(instance == this){
            instance = null;
        }
    }
}
