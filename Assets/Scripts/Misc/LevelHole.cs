using System;
using UnityEngine;

public class LevelHole : MonoBehaviour
{
    [SerializeField] GameEvent OnNextLevelTrigger;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            OnNextLevelTrigger.Raise();
        }
    }
}
