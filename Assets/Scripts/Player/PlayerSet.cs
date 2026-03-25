using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSet : MonoBehaviour
{
    private Character character;
    private InventorySystem hotbarSystem;
    private InventorySystem bagSystem;
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
        character = GetComponent<Character>();
        inventoryHolder = GetComponent<InventoryHolder>();
    }

    void Start()
    {
        hotbarSystem = inventoryHolder.HotbarSystem;
        bagSystem = inventoryHolder.BagSystem;
    }

    void Update()
    {
        ChooseSlot();

        if (Input.GetKeyDown(KeyCode.F))
        {
            EquipInRightHand();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            KeyBoardDropItem();
        }
    }

    private void ChooseSlot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) hotbarSystem.HotbarPos = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) hotbarSystem.HotbarPos = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) hotbarSystem.HotbarPos = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4)) hotbarSystem.HotbarPos = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5)) hotbarSystem.HotbarPos = 4;
        if (Input.GetKeyDown(KeyCode.Alpha6)) hotbarSystem.HotbarPos = 5;
        if (Input.GetKeyDown(KeyCode.Alpha7)) hotbarSystem.HotbarPos = 6;
        if (Input.GetKeyDown(KeyCode.Alpha8)) hotbarSystem.HotbarPos = 7;
        if (Input.GetKeyDown(KeyCode.Alpha9)) hotbarSystem.HotbarPos = 8;
        if (Input.GetKeyDown(KeyCode.Alpha0)) hotbarSystem.HotbarPos = 9;

        float scroll = Input.mouseScrollDelta.y;

        if (scroll != 0)
        {
            if (scroll > 0f)
            {
                hotbarSystem.HotbarPos--;

                if (hotbarSystem.HotbarPos < 0)
                    hotbarSystem.HotbarPos = 9;
            }
            else if (scroll < 0f)
            {
                hotbarSystem.HotbarPos++;

                if (hotbarSystem.HotbarPos > 9)
                    hotbarSystem.HotbarPos = 0;
            }
        }
    }

    private void KeyBoardDropItem()
    {
        InventorySlot inventorySlot = hotbarSystem.ChooseItem();



    }

    private void EquipInRightHand()
    {
        InventorySlot inventorySlot = hotbarSystem.ChooseItem();

        if (inventorySlot != null)
        {
            if (inventorySlot.ItemData != null)
            {
                InventoryItemData temporaryItem = RightHand.ItemData;
                int temporaryItemStack = RightHand.StackSize;

                if (character.RightHandTransform.childCount > 0)
                {
                    foreach (Transform child in character.RightHandTransform)
                    {
                        Destroy(child.gameObject);
                    }
                }

                RightHand.UpdateInventorySlot(inventorySlot.ItemData, inventorySlot.StackSize);

                GameObject equippedItem = Instantiate(inventorySlot.ItemData.ItemPrefab, character.RightHandTransform);
                equippedItem.transform.localPosition = Vector3.zero;
                equippedItem.transform.localRotation = Quaternion.identity;

                if (temporaryItem != null)
                    inventorySlot.UpdateInventorySlot(temporaryItem, temporaryItemStack);
                else
                    inventorySlot.ClearSlot();

                hotbarSystem.OnInventorySlotsChanged?.Invoke(inventorySlot);
            }
            else if (inventorySlot.ItemData == null && RightHand.ItemData != null)
            {
                InventoryItemData temporaryItem = RightHand.ItemData;
                int temporaryItemStack = RightHand.StackSize;

                if (character.RightHandTransform.childCount > 0)
                {
                    foreach (Transform child in character.RightHandTransform)
                    {
                        Destroy(child.gameObject);
                    }
                }

                inventorySlot.UpdateInventorySlot(temporaryItem, temporaryItemStack);

                RightHand.ClearSlot();

                hotbarSystem.OnInventorySlotsChanged?.Invoke(inventorySlot);
            }
        }
    }
}
