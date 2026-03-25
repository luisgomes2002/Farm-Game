using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [Header("Configurações de Tamanho")]
    [SerializeField] private int inventorySize;
    [SerializeField] private int bagSize;

    [Header("Sistemas (Visíveis no Inspector)")]
    [SerializeField] private InventorySystem hotbarSystem;
    [SerializeField] private InventorySystem bagSystem;

    public InventorySystem HotbarSystem => hotbarSystem;
    public InventorySystem BagSystem => bagSystem;

    public static UnityAction<InventorySystem> OnDynamicInventoryDisplayRequested;

    private void Awake()
    {
        hotbarSystem = new InventorySystem(inventorySize);
        bagSystem = new InventorySystem(bagSize);
    }
}