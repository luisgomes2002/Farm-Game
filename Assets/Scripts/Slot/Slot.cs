using UnityEngine;

public class Slot : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Seed seed;

    private bool dugHole;
    private bool isPlanted;


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
            spriteRenderer.sprite = seed.SeedSprite;
            isPlanted = true;
        }
    }

    public void OnWet()
    {
        spriteRenderer.sprite = seed.WetSeedSprite;
    }

    private void OnCollecting()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.sprite = hole;
        }
    }

}
