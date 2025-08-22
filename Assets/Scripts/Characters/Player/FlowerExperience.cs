using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerExperience : MonoBehaviour
{
    [Header("exp info")]
    public float experience = 0f;
    public int level = 1;
    [SerializeField] private float expToLevel = 10f;
    [SerializeField] private float expLevelFactor = 0.1f;
    private readonly float expFactor = 1f;

    private SpriteRenderer mySpriteRenderer;

    public event Action<float, float> OnExpReceived;
    public event Action<int> OnLevelUP;

    [Header("Sprites")]
    [SerializeField] private GameObject flower;
    [SerializeField] private Sprite[] sprites;

    [Header("Upgrades")]
    [SerializeField] private List<GameObject> upgradesList = new();

    private void Awake()
    {
        if (flower == null)
        {
            Debug.Log("sem flower");
        }
        else
        {
            mySpriteRenderer = flower.GetComponent<SpriteRenderer>();

        }
    }

    void Start()
    {
        ReceiveExperience(0); // so pra atualizar o slider
        OnLevelUP?.Invoke(level);
    }

    private void UpdateSpriteImage()
    {
        if (sprites == null || sprites.Length == 0) return;


        float normalized = Mathf.Clamp01(experience / expToLevel);
        int index = Mathf.FloorToInt(normalized * (sprites.Length));

        mySpriteRenderer.sprite = sprites[index];
    }

    public void ReceiveExperience(int exp)
    {
        experience += exp;
        OnExpReceived?.Invoke(experience, expToLevel);
        if (experience >= expToLevel)
        {
            experience -= expToLevel;
            LevelUp();
        }
        UpdateSpriteImage();
    }

    private void LevelUp()
    {
        level++;
        expToLevel *= expFactor + expLevelFactor;
        OnLevelUP?.Invoke(level);
        SpawnPowerUp();
        //dopra os upgrades;
    }

    private void SpawnPowerUp()
    {
        int randomUpgrade = UnityEngine.Random.Range(0, upgradesList.Count);
        Instantiate(upgradesList[randomUpgrade], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }

    public void ResetLevel()
    {
        level = 1;
        expToLevel = 10;
        OnLevelUP?.Invoke(level);
        experience = 0;
        ReceiveExperience(0);
    }
}
