using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerExperience : MonoBehaviour
{
    public int experience = 0;
    [SerializeField] SpriteRenderer mySpriteRenderer;
    [SerializeField] private List<Sprite> imageList = new List<Sprite>();

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void UpdateSpriteIMage()
    {

    }

    public void ReceiveExperience(int exp)
    {
        experience += exp;
        if (exp == 2)
        {
            mySpriteRenderer.sprite = imageList[1];
        }
    }
}
