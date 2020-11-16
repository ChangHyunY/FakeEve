using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyObj", 2.0f);
    }

    void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}
