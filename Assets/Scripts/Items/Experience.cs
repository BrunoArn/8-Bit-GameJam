using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private int amount;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FlowerExperience>(out FlowerExperience flowerExperience))
        {
            flowerExperience.ReceiveExperience(amount);
        }
    }
}
