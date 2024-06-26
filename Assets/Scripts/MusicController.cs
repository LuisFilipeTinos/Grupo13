using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);       
    }
}
