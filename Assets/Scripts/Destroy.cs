using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Update()
    {
        DestroyObjectDelayed();
    }

    void DestroyObjectDelayed()
    {
        Destroy(this.gameObject, 2);
    }
}
