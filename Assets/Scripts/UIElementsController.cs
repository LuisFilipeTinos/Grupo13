using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementsController : MonoBehaviour
{
    [SerializeField] LevelLoaderController levelLoaderController;

    public void BackToMainMenu()
    {
        StartCoroutine(levelLoaderController.LoadLevel(0));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TutorialScene()
    {
        StartCoroutine(levelLoaderController.LoadLevel(3));
    }

    public void CreditsScene()
    {
        StartCoroutine(levelLoaderController.LoadLevel(1));
    }
}
