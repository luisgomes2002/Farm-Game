using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [Header("Core Attributes")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentStamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private float defenseRating;
    [SerializeField] private float armor;

    [Header("Skills - Fishing")]
    [SerializeField] private int fishingLevel;
    [SerializeField] private float fishingCurrentXP;
    [SerializeField] private float fishingRequiredXP;

    [Header("Skills - Cooking")]
    [SerializeField] private int cookingLevel;
    [SerializeField] private float cookingCurrentXP;
    [SerializeField] private float cookingRequiredXP;

    [Header("Skills - Combat")]
    [SerializeField] private int swordSkill;
    [SerializeField] private float swordCurrentXP;
    [SerializeField] private float swordRequiredXP;

    [Header("Skills - Farming")]
    [SerializeField] private int farmingLevel;
    [SerializeField] private float farmingCurrentXP;
    [SerializeField] private float farmingRequiredXP;

    [Header("Skills - Mining")]
    [SerializeField] private int miningLevel;
    [SerializeField] private float miningCurrentXP;
    [SerializeField] private float miningRequiredXP;

    [Header("Skills - Alchemy")]
    [SerializeField] private int alchemyLevel;
    [SerializeField] private float alchemyCurrentXP;
    [SerializeField] private float alchemyRequiredXP;

    [Header("Skills - Crafting")]
    [SerializeField] private int craftingLevel;
    [SerializeField] private float craftingCurrentXP;
    [SerializeField] private float craftingRequiredXP;

    [Header("Skills - Smithing")]
    [SerializeField] private int smithingLevel;
    [SerializeField] private float smithingCurrentXP;
    [SerializeField] private float smithingRequiredXP;

    [Header("Movement & Physics")]
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private float initialSpeed;
    private Vector2 direction;
    private Rigidbody2D rig;

    [Header("Interaction & Inventory")]
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask slotLayer;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private List<ItemPickUp> itemPickUps = new List<ItemPickUp>();
    private List<Slot> detectedSlots = new List<Slot>();
    private ItemDetector itemDetector;

    [Header("State Flags")]
    [SerializeField] private bool canMove;
    private bool isRunning;
    private bool isRolling;
    private bool canClick;

    // --- Properties ---
    public Rigidbody2D Rig { get => rig; set => rig = value; }
    public Vector2 Direction { get => direction; set => direction = value; }
    public float Speed { get => speed; set => speed = value; }
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }
    public float InitialSpeed { get => initialSpeed; set => initialSpeed = value; }
    public bool IsRunning { get => isRunning; set => isRunning = value; }
    public bool IsRolling { get => isRolling; set => isRolling = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool CanClick { get => canClick; set => canClick = value; }
    public List<Slot> DetectedSlots { get => detectedSlots; set => detectedSlots = value; }

    private void Awake()
    {
        Rig = GetComponent<Rigidbody2D>();
        itemDetector = GetComponent<ItemDetector>();

        InitialSpeed = speed;
        canMove = true;
        canClick = true;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        DetectSlot();
        // DetectItem();
    }

    private void DetectSlot()
    {
        detectedSlots.Clear();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRange, slotLayer);

        foreach (Collider2D hit in hits)
        {
            Slot slot = hit.GetComponent<Slot>();
            if (slot != null)
            {
                detectedSlots.Add(slot);
            }
        }
    }

    // DETECTOR PARA PEGAR O ITEM COM O MOUSE, NÂO ESTA EM USO USADO JUNTO COM o ARQUIVO ItemDetector.cs

    // private void DetectItem() 
    // {
    //     itemPickUps.Clear();
    //     Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRange, itemLayer);

    //     foreach (Collider2D hit in hits)
    //     {
    //         ItemPickUp item = hit.GetComponent<ItemPickUp>();
    //         if (item != null)
    //         {
    //             itemPickUps.Add(item);
    //             Debug.Log($"Item detectado: {item.name}");
    //         }
    //     }

    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         ItemPickUp clickedItem = itemDetector.OnClickItem();
    //         if (clickedItem != null && itemPickUps.Contains(clickedItem))
    //         {
    //             Debug.Log($"Item clicado: {clickedItem.name}");
    //             clickedItem.GetItem(this);
    //         }
    //         else
    //         {
    //             Debug.Log("Nenhum item válido clicado.");
    //         }
    //     }
    // }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position, interactionRange);
    // }
}