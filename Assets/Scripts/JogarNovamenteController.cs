using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogarNovamenteController : MonoBehaviour
{
    [SerializeField] LevelLoaderController levelLoader;
  public void StartGame()
    {
        StartCoroutine(levelLoader.LoadLevel(5));
    }
}
