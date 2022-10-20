using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSettings : MonoBehaviour
{
    [SerializeField] GameObject activeSettings;
    public void Active()
    {
        activeSettings.SetActive(true);
    }
    public void UnActive()
    {
        activeSettings.SetActive(false);
    }
}
