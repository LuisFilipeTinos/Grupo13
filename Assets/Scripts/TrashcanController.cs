using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrashcanController : MonoBehaviour
{

    Vector2 cursorPos;
    private Dictionary<string, Dictionary<string, System.Action<GameObject>>> actions;

    [SerializeField] LevelLoaderController levelLoader;
    [SerializeField] List<GameObject> lifeImages;

    [SerializeField] AudioSource audioSrcCorrect;
    [SerializeField] AudioSource audioSrcIncorrect;

    int countToGainLife;
    int lifes;

    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        countToGainLife = 0;

        actions = new Dictionary<string, Dictionary<string, System.Action<GameObject>>>()
        {
            { "GlassTrashcan", new Dictionary<string, System.Action<GameObject>>()
                {
                    { "Glass", (collisionGameObject) => GainHealth(collisionGameObject) },
                    { "Metal", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Plastic", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Paper", (collisionGameObject) => LoseHealth(collisionGameObject) },
                }
            },
            { "PaperTrashcan", new Dictionary<string, System.Action<GameObject>>()
                {
                    { "Glass", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Metal", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Plastic", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Paper", (collisionGameObject) => GainHealth(collisionGameObject) },
                }
            },
            { "PlasticTrashcan", new Dictionary<string, System.Action<GameObject>>()
                {
                    { "Glass", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Metal", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Plastic", (collisionGameObject) => GainHealth(collisionGameObject) },
                    { "Paper", (collisionGameObject) => LoseHealth(collisionGameObject) },
                }
            },
            { "MetalTrashcan", new Dictionary<string, System.Action<GameObject>>()
                {
                    { "Glass", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Metal", (collisionGameObject) => GainHealth(collisionGameObject) },
                    { "Plastic", (collisionGameObject) => LoseHealth(collisionGameObject) },
                    { "Paper", (collisionGameObject) => LoseHealth(collisionGameObject) },
                }
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (actions.ContainsKey(this.transform.tag) &&
            actions[this.transform.tag].ContainsKey(collision.gameObject.tag))
            actions[this.transform.tag][collision.gameObject.tag](collision.gameObject);
    }

    public void LoseHealth(GameObject collisionGameObject)
    {
        audioSrcIncorrect.Play();
        Destroy(collisionGameObject);

        if (lifes > 1)
        {
            lifes--;
            lifeImages.Where(x => x.activeSelf).LastOrDefault().SetActive(false);
        }
        else
        {
            StartCoroutine(levelLoader.LoadLevel(4));
        }
    }

    public void GainHealth(GameObject collisionGameObject)
    {
        audioSrcCorrect.Play();
        Destroy(collisionGameObject);

        if (lifes < 3)
        {
            countToGainLife++;

            if (countToGainLife == 10)
            {
                countToGainLife = 0;
                lifes++;
                lifeImages.Where(x => !x.activeSelf).FirstOrDefault().SetActive(true);
            }
        }
    }
}
