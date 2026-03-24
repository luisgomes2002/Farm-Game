using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Transform (Character's Bones)")]
    [SerializeField] private Transform rightHandTransform;

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
    private List<Slot> detectedSlots = new List<Slot>();

    [Header("State Flags")]
    [SerializeField] private bool canMove;
    private bool isRunning;
    private bool isRolling;
    private bool canClick;

    // Transform
    public Transform RightHandTransform { get => rightHandTransform; set => rightHandTransform = value; }

    // Core
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentStamina { get => currentStamina; set => currentStamina = value; }
    public float MaxStamina { get => maxStamina; set => maxStamina = value; }
    public float DefenseRating { get => defenseRating; set => defenseRating = value; }
    public float Armor { get => armor; set => armor = value; }

    // Skills - Fishing
    public int FishingLevel { get => fishingLevel; set => fishingLevel = value; }
    public float FishingCurrentXP { get => fishingCurrentXP; set => fishingCurrentXP = value; }
    public float FishingRequiredXP { get => fishingRequiredXP; set => fishingRequiredXP = value; }

    // Skills - Cooking
    public int CookingLevel { get => cookingLevel; set => cookingLevel = value; }
    public float CookingCurrentXP { get => cookingCurrentXP; set => cookingCurrentXP = value; }
    public float CookingRequiredXP { get => cookingRequiredXP; set => cookingRequiredXP = value; }

    // Skills - Combat
    public int SwordSkill { get => swordSkill; set => swordSkill = value; }
    public float SwordCurrentXP { get => swordCurrentXP; set => swordCurrentXP = value; }
    public float SwordRequiredXP { get => swordRequiredXP; set => swordRequiredXP = value; }

    // Skills - Farming
    public int FarmingLevel { get => farmingLevel; set => farmingLevel = value; }
    public float FarmingCurrentXP { get => farmingCurrentXP; set => farmingCurrentXP = value; }
    public float FarmingRequiredXP { get => farmingRequiredXP; set => farmingRequiredXP = value; }

    // Skills - Mining
    public int MiningLevel { get => miningLevel; set => miningLevel = value; }
    public float MiningCurrentXP { get => miningCurrentXP; set => miningCurrentXP = value; }
    public float MiningRequiredXP { get => miningRequiredXP; set => miningRequiredXP = value; }

    // Skills - Alchemy
    public int AlchemyLevel { get => alchemyLevel; set => alchemyLevel = value; }
    public float AlchemyCurrentXP { get => alchemyCurrentXP; set => alchemyCurrentXP = value; }
    public float AlchemyRequiredXP { get => alchemyRequiredXP; set => alchemyRequiredXP = value; }

    // Skills - Crafting
    public int CraftingLevel { get => craftingLevel; set => craftingLevel = value; }
    public float CraftingCurrentXP { get => craftingCurrentXP; set => craftingCurrentXP = value; }
    public float CraftingRequiredXP { get => craftingRequiredXP; set => craftingRequiredXP = value; }

    // Skills - Smithing
    public int SmithingLevel { get => smithingLevel; set => smithingLevel = value; }
    public float SmithingCurrentXP { get => smithingCurrentXP; set => smithingCurrentXP = value; }
    public float SmithingRequiredXP { get => smithingRequiredXP; set => smithingRequiredXP = value; }

    // Movement & Physics
    public float Speed { get => speed; set => speed = value; }
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }
    public float InitialSpeed { get => initialSpeed; set => initialSpeed = value; }
    public Vector2 Direction { get => direction; set => direction = value; }
    public Rigidbody2D Rig { get => rig; set => rig = value; }

    // Interaction & Inventory
    public float InteractionRange { get => interactionRange; set => interactionRange = value; }
    public LayerMask SlotLayer { get => slotLayer; set => slotLayer = value; }
    public List<Slot> DetectedSlots { get => detectedSlots; set => detectedSlots = value; }

    // State Flags
    public bool CanMove { get => canMove; set => canMove = value; }
    public bool IsRunning { get => isRunning; set => isRunning = value; }
    public bool IsRolling { get => isRolling; set => isRolling = value; }
    public bool CanClick { get => canClick; set => canClick = value; }

    private void Awake()
    {
        Rig = GetComponent<Rigidbody2D>();

        InitialSpeed = Speed;
        CanMove = true;
        CanClick = true;
    }

    private void FixedUpdate()
    {
        DetectSlot();
    }

    private void DetectSlot()
    {
        DetectedSlots.Clear();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, InteractionRange, SlotLayer);

        foreach (Collider2D hit in hits)
        {
            Slot slot = hit.GetComponent<Slot>();
            if (slot != null)
            {
                DetectedSlots.Add(slot);
            }
        }
    }
}
