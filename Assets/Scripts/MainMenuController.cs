using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] LevelLoaderController levelLoader;
    public void LoadLevel()
    {
        StartCoroutine(levelLoader.LoadLevel(5));
    }
}
