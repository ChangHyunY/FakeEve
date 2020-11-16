using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    private static SoundMgr _instance = null;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        if (_instance != this)
        {
            Destroy(_instance);
        }
    }
}
