using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask slotLayer;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private bool canMove;

    private List<Slot> detectedSlots = new List<Slot>();
    [SerializeField] private List<ItemPickUp> itemPickUps = new List<ItemPickUp>();
    private ItemDetector itemDetector;

    private Rigidbody2D rig;
    private Vector2 direction;
    private float initialSpeed;
    private bool isRunning;
    private bool isRolling;
    private bool canClick;

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