using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    public new string name;
    public int point;

    public Fruit()
    {
        this.name = "";
        this.point = 0;
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
