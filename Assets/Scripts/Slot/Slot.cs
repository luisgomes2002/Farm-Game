using System;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Seed seed;
    [SerializeField] private int wetSpriteCount = 0;
    [SerializeField] private int spritCount = 0;

    private bool dugHole;
    private bool isPlanted;
    private bool hasFruit;


    private void Awake()
    {

    }

    private void Update()
    {
        if (dugHole)
        {
            if (!isPlanted)
            {
                OnPlant();
            }
        }
    }

    public void DigHole()
    {
        spriteRenderer.sprite = hole;
        dugHole = true;
        isPlanted = false;
    }

    private void OnPlant()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.sprite = seed.GrowthSprites[spritCount];
            isPlanted = true;
        }
    }

    public void OnWet()
    {
        if (isPlanted)
        {
            spriteRenderer.sprite = seed.GrowthWetSprites[wetSpriteCount];
        }
    }

    public void Growing()
    {
        wetSpriteCount++;
        spritCount++;
    }

    private void OnCollecting()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasFruit)
        {
            spriteRenderer.sprite = hole;
            dugHole = true; // Trocar depois
            isPlanted = false;
            hasFruit = false;
        }
    }
}
