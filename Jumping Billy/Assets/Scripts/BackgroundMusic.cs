using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusicControll;
    void Awake()
    {
        if(backgroundMusicControll == null)
        {   
            backgroundMusicControll = this;
            DontDestroyOnLoad(backgroundMusicControll);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
