using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSet : MonoBehaviour
{
    private Player player;
    private InventorySystem inventorySystem;

    [SerializeField] private GameObject rigthHand;
    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject headSlot;
    [SerializeField] private GameObject chestSlot;
    [SerializeField] private GameObject legSlot;
    [SerializeField] private GameObject footSlot;

    public GameObject RigthHand { get => rigthHand; set => rigthHand = value; }
    public GameObject LeftHand { get => leftHand; set => leftHand = value; }
    public GameObject HeadSlot { get => headSlot; set => headSlot = value; }
    public GameObject ChestSlot { get => chestSlot; set => chestSlot = value; }
    public GameObject LegSlot { get => legSlot; set => legSlot = value; }
    public GameObject FootSlot { get => footSlot; set => footSlot = value; }


    private void Awake()
    {
        player = GetComponent<Player>();
        inventorySystem = GetComponent<InventorySystem>();
    }

    void Start()
    {

    }

    void Update()
    {
        // lembrar de verificar se tem um item na mão do personagem antes
        if (Input.GetKeyDown(KeyCode.F))
        {
            InventorySlot inventorySlot = inventorySystem.ChooseItem();

            if (inventorySlot != null && inventorySlot.ItemData != null)
            {
                InventoryItemData itemData = inventorySlot.ItemData;

                GameObject equippedItem = Instantiate(itemData.ItemPrefab, rigthHand.transform);

                equippedItem.transform.localPosition = Vector3.zero;
                equippedItem.transform.localRotation = Quaternion.identity;
            }
        }
    }

}
