using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI readyText;
    [SerializeField] Animator faderAnimator;

    [SerializeField] GameObject levelLabel;
    [SerializeField] GameObject lifeLabel;
    [SerializeField] GameObject lifeObjects;
    [SerializeField] GameObject timer;

    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
        lifeLabel.SetActive(false);
        levelLabel.SetActive(false);
        lifeObjects.SetActive(false);
        timer.SetActive(false);
        StartCoroutine(BeginLevel());
    }
    public IEnumerator BeginLevel()
    {
        yield return new WaitForSeconds(1f);

        readyText.text = "Preparado?";
        readyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);

        readyText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);

        readyText.text = "Hora de reciclar!";
        readyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);

        readyText.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        faderAnimator.Play("FadeOutAnim");
        yield return new WaitForSeconds(0.5f);
        canSpawn = true;

        lifeLabel.SetActive(true);
        levelLabel.SetActive(true);
        lifeObjects.SetActive(true);
        timer.SetActive(true);
    }
}
