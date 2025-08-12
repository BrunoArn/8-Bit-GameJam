using Unity.VisualScripting;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
