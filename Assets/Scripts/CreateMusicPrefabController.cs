using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMusicPrefabController : MonoBehaviour
{
    GameObject musicPrefab;

    void Start()
    {
        musicPrefab = (GameObject)Resources.Load("Music");

        var musicObjects = GameObject.FindGameObjectsWithTag("Music");

        if (musicObjects.Length == 0)
            Instantiate(musicPrefab);
    }
}
