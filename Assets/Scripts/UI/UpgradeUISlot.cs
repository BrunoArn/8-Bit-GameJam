using System.Collections;
using TMPro;
using UnityEngine;

public class UpgradeUISlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private GameObject slot;

    [SerializeField] AnimationClip enterAnimation;

    private void Start() {
        StartCoroutine(WaitAnimationRoutine());
    }

    public void Initialize(string text)
    {
        if (textUI == null)
        {
            Debug.Log("text ui é null");
        }
        textUI.text = text;
    }

    IEnumerator WaitAnimationRoutine()
    {
        yield return new WaitForSeconds(enterAnimation.length);
        Destroy(this.gameObject);
    }
}
