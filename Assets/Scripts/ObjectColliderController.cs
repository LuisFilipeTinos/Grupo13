using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColliderController : MonoBehaviour
{
    [SerializeField] GameObject trashCan;
    [SerializeField] TrashcanController trashcanController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plastic") && trashCan.CompareTag("PlasticTrashcan") ||
            collision.gameObject.CompareTag("Paper") && trashCan.CompareTag("PaperTrashcan") ||
            collision.gameObject.CompareTag("Metal") && trashCan.CompareTag("MetalTrashcan") ||
            collision.gameObject.CompareTag("Glass") && trashCan.CompareTag("GlassTrashcan"))
        {
            trashcanController.LoseHealth(collision.gameObject);
        }
        else
            Destroy(collision.gameObject);
    }
}
