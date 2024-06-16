using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI readyText;
    [SerializeField] Animator faderAnimator;
    public bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
        StartCoroutine(BeginLevel());
    }
    public IEnumerator BeginLevel()
    {
        readyText.text = "Preparado?";
        readyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);

        readyText.gameObject.SetActive(false);

        readyText.text = "Vai!";
        readyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);

        faderAnimator.Play("FadeOutAnim");
        yield return new WaitForSeconds(0.5f);
        canSpawn = true;
    }
}
