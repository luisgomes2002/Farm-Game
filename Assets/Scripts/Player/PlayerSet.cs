using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSet : MonoBehaviour
{
    private Player player;
    private InventorySystem inventorySystem;
    private InventoryHolder inventoryHolder;

    [SerializeField] private InventorySlot rightHand;
    [SerializeField] private InventorySlot leftHand;
    [SerializeField] private InventorySlot headSlot;
    [SerializeField] private InventorySlot chestSlot;
    [SerializeField] private InventorySlot legSlot;
    [SerializeField] private InventorySlot footSlot;

    public InventorySlot RightHand { get => rightHand; set => rightHand = value; }
    public InventorySlot LeftHand { get => leftHand; set => leftHand = value; }
    public InventorySlot HeadSlot { get => headSlot; set => headSlot = value; }
    public InventorySlot ChestSlot { get => chestSlot; set => chestSlot = value; }
    public InventorySlot LegSlot { get => legSlot; set => legSlot = value; }
    public InventorySlot FootSlot { get => footSlot; set => footSlot = value; }


    private void Awake()
    {
        player = GetComponent<Player>();
        inventoryHolder = GetComponent<InventoryHolder>();

        inventorySystem = inventoryHolder.InventorySystem;
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            EquipInRightHand();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            KeyBoardDropItem();
        }
    }

    private void KeyBoardDropItem()
    {
        InventorySlot inventorySlot = inventorySystem.ChooseItem();

        

    }

    private void EquipInRightHand()
    {
        InventorySlot inventorySlot = inventorySystem.ChooseItem();

        if (inventorySlot != null)
        {
            if (inventorySlot.ItemData != null)
            {
                InventoryItemData temporaryItem = RightHand.ItemData;
                int temporaryItemStack = RightHand.StackSize;

                if (player.RightHandTransform.childCount > 0)
                {
                    foreach (Transform child in player.RightHandTransform)
                    {
                        Destroy(child.gameObject);
                    }
                }

                RightHand.UpdateInventorySlot(inventorySlot.ItemData, inventorySlot.StackSize);

                GameObject equippedItem = Instantiate(inventorySlot.ItemData.ItemPrefab, player.RightHandTransform);
                equippedItem.transform.localPosition = Vector3.zero;
                equippedItem.transform.localRotation = Quaternion.identity;

                if (temporaryItem != null)
                    inventorySlot.UpdateInventorySlot(temporaryItem, temporaryItemStack);
                else
                    inventorySlot.ClearSlot();

                inventorySystem.OnInventorySlotsChanged?.Invoke(inventorySlot);
            }
            else if (inventorySlot.ItemData == null && RightHand.ItemData != null)
            {
                InventoryItemData temporaryItem = RightHand.ItemData;
                int temporaryItemStack = RightHand.StackSize;

                if (player.RightHandTransform.childCount > 0)
                {
                    foreach (Transform child in player.RightHandTransform)
                    {
                        Destroy(child.gameObject);
                    }
                }

                inventorySlot.UpdateInventorySlot(temporaryItem, temporaryItemStack);

                RightHand.ClearSlot();

                inventorySystem.OnInventorySlotsChanged?.Invoke(inventorySlot);
            }
        }
    }
}
