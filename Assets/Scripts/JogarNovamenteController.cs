using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogarNovamenteController : MonoBehaviour
{
  public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
