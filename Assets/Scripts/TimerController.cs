using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 30f;
    TextMeshProUGUI timerText;
    [SerializeField] LevelLoaderController levelLoaderController;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");

        if (currentTime <= 0)
            StartCoroutine(levelLoaderController.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
}
