using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanController : MonoBehaviour
{

    Vector2 cursorPos;
    private Dictionary<string, Dictionary<string, System.Action<GameObject>>> actions;

    // Start is called before the first frame update
    void Start()
    {
        actions = new Dictionary<string, Dictionary<string, System.Action<GameObject>>>()
        {
            { "GlassTrashcan", new Dictionary<string, System.Action<GameObject>>()
                {
                    { "Glass", (collisionGameObject) => Destroy(collisionGameObject) },
                    { "Metal", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Plastic", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Paper", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                }
            },
            { "PaperTrashcan", new Dictionary<string, System.Action<GameObject>>()
                {
                    { "Glass", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Metal", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Plastic", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Paper", (collisionGameObject) => Destroy(collisionGameObject) },
                }
            },
            { "PlasticTrashcan", new Dictionary<string, System.Action<GameObject>>()
                {
                    { "Glass", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Metal", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Plastic", (collisionGameObject) => Destroy(collisionGameObject) },
                    { "Paper", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                }
            },
            { "MetalTrashcan", new Dictionary<string, System.Action<GameObject>>()
                {
                    { "Glass", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Metal", (collisionGameObject) => Destroy(collisionGameObject) },
                    { "Plastic", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
                    { "Paper", (collisionGameObject) => { /* Lógica para perder vida e/ou game over */ } },
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
}
