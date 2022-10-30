using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class DontDestroyOnloadManager : MonoBehaviour
{
    public static DontDestroyOnloadManager control;

    private void Awake()
    {
        if(control != null)
        {
            Destroy(gameObject);
        }
        else
        {
            control = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
