using TMPro;
using UnityEngine;

public class ExpProgressionUI : MonoBehaviour
{
    [SerializeField] private Transform fillExpBar;
    [SerializeField] FlowerExperience experience;

    [SerializeField] private TextMeshProUGUI levelText;

    private void Awake()
    {
        if (fillExpBar == null)
        {
            Debug.Log("estamos sem a Exp fill");
        }

        if (experience)
        {
            experience.OnExpReceived += SetExpValue;
            experience.OnLevelUP += UpdateLevelText;
        }
    }

    void OnDestroy()
    {
        experience.OnExpReceived -= SetExpValue;
    }

    public void SetExpValue(float current, float max)
    {
        float t = current / max;
        t = Mathf.Clamp01(t);
        fillExpBar.localScale = new Vector3(t, 1f, 1f);
    }

    private void UpdateLevelText(int level)
    {
        levelText.text = "Level " + level.ToString();
    }
}
