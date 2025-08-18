using System;
using UnityEngine;

public class LevelHole : MonoBehaviour
{
    public event Action OnNextLevelTrigger;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            OnNextLevelTrigger.Invoke();
        }
    }
}
