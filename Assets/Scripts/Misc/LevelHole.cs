using System;
using System.Collections;
using UnityEngine;

public class LevelHole : MonoBehaviour
{
    [SerializeField] GameEvent OnNextLevelTrigger;
    [SerializeField] AnimationClip spawnAnim;

    private void Start()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(AnimationWaitRoutine());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            OnNextLevelTrigger.Raise();
        }
    }

    private IEnumerator AnimationWaitRoutine()
    {
        yield return new WaitForSeconds(spawnAnim.length);
        GetComponent<Collider2D>().enabled = true;
    }
}
