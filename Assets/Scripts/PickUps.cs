using Unity.VisualScripting;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.GetComponent<PlayerProjectile>())
            Destroy(this.gameObject);
    }
}
