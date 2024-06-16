using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    GameObject plasticTrashPrefab;
    GameObject paperTrashPrefab;
    GameObject metalTrashPrefab;
    GameObject glassTrashPrefab;

    [SerializeField] float maxTime;
    float time = 0;

    [SerializeField] float xStartLimit;
    [SerializeField] float xEndLimit;

    List<GameObject> listOfPrefabs;

    [SerializeField] LevelController levelController;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        plasticTrashPrefab = (GameObject)Resources.Load("PlasticTrash");
        paperTrashPrefab = (GameObject)Resources.Load("PaperTrash");
        metalTrashPrefab = (GameObject)Resources.Load("MetalTrash");
        glassTrashPrefab = (GameObject)Resources.Load("GlassTrash");

        listOfPrefabs = new List<GameObject>
        {
            plasticTrashPrefab,
            paperTrashPrefab,
            metalTrashPrefab,
            glassTrashPrefab
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (levelController.canSpawn)
        {
            time += Time.deltaTime;
            if (time >= maxTime)
            {
                var randomPos = Random.Range(0, listOfPrefabs.Count);
                var selectedPrefab = listOfPrefabs[randomPos];

                var positionX = Random.Range(xStartLimit, xEndLimit);

                var instantiatedPrefab = Instantiate(selectedPrefab);
                instantiatedPrefab.transform.position = new Vector2(positionX, this.transform.position.y);
                time = 0;
            }
        }
    }
}
